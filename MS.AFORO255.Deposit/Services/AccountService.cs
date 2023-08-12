using Aforo255.Cross.Http.Src;
using MS.AFORO255.Deposit.DTOs;
using MS.AFORO255.Deposit.Models;
using Polly;
using Polly.CircuitBreaker;

namespace MS.AFORO255.Deposit.Services;

public class AccountService : IAccountService
{
    private readonly IConfiguration _configuration;
    private readonly ITransactionService _transactionService;
    private readonly IHttpClient _httpClient;

    public AccountService(IConfiguration configuration, ITransactionService transactionService, IHttpClient httpClient)
    {
        _configuration = configuration;
        _transactionService = transactionService;
        _httpClient = httpClient;
    }
    public async Task<bool> DepositAccount(AccountRequest request)
    {
        string uri = _configuration["proxy:urlAccountTransaction"];
        var response = await _httpClient.PostAsync(uri, request);
        response.EnsureSuccessStatusCode();
        return true;
    }

    public bool DepositReverse(TransactionModel request)
    {
        _transactionService.DepositReverse(request);
        return true;
    }
    public bool Execute(TransactionModel request)
    {
        bool response = false;

        var circuitBreakerPolicy = Policy.Handle<Exception>().
            CircuitBreaker(3, TimeSpan.FromSeconds(10));

        var retry = Policy.Handle<Exception>()
                .WaitAndRetryForever(attemp => TimeSpan.FromSeconds(10))
                .Wrap(circuitBreakerPolicy);

        retry.Execute(() =>
        {
            if (circuitBreakerPolicy.CircuitState == CircuitState.Closed)
            {
                circuitBreakerPolicy.Execute(() =>
                {
                    response = DepositAccount(new AccountRequest(request.AccountId, request.Amount)).Result;
                });
            }

            if (circuitBreakerPolicy.CircuitState != CircuitState.Closed)
            {
                DepositReverse(new TransactionModel(request.Amount, request.AccountId, "Deposit Reverse"));
                response = false;
            }
        });

        return response;
    }
}

