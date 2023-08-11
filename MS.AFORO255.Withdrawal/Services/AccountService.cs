﻿using Aforo255.Cross.Http.Src;
using MS.AFORO255.Withdrawal.DTOs;
using MS.AFORO255.Withdrawal.Models;

namespace MS.AFORO255.Withdrawal.Services;

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
    public async Task<bool> WithdrawalAccount(AccountRequest request)
    {
        string uri = _configuration["proxy:urlAccountTransaction"];
        var response = await _httpClient.PostAsync(uri, request);
        response.EnsureSuccessStatusCode();
        return true;
    }

    public bool WithdrawalReverse(TransactionModel request)
    {
        _transactionService.WithdrawalReverse(request);
        return true;
    }
    public bool Execute(TransactionModel request)
    {
        bool response = false;       

        response = WithdrawalAccount(new AccountRequest(request.AccountId, request.Amount)).Result;
                
        return response;
    }
}

