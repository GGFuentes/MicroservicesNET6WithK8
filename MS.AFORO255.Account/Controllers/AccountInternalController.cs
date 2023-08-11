using Microsoft.AspNetCore.Mvc;
using MS.AFORO255.Account.DTOs;
using MS.AFORO255.Account.Service;

namespace MS.AFORO255.Account.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountInternalController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountInternalController(IAccountService accountService) => _accountService = accountService;

    [HttpPost("Deposit")]
    public IActionResult Deposit([FromBody] AccountRequest request)
    {
        Models.Account? result = _accountService.GetAll().FirstOrDefault(x => x.AccountId == request.accountId);
        if (result is null) return BadRequest();

        Models.Account account = new Models.Account(request.accountId,
            result.TotalAmount + request.amount, result.CustomerId, result.Customer);
        _accountService.Deposit(account);

        return Ok();
    }

    [HttpPost("Withdrawal")]
    public IActionResult Withdrawal([FromBody] AccountRequest request)
    {
        Models.Account? result = _accountService.GetAll().FirstOrDefault(x => x.AccountId == request.accountId);
        if (result is null) return BadRequest();
        if (result.TotalAmount < request.amount) return BadRequest(new { message = "The indicated amount cannot be withdrawal" });

        Models.Account account = new Models.Account(request.accountId,
            result.TotalAmount - request.amount, result.CustomerId, result.Customer);
        _accountService.Withdrawal(account);

        return Ok();
    }
}

