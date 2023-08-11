using Microsoft.AspNetCore.Mvc;
using MS.AFORO255.Account.Service;

namespace MS.AFORO255.Account.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService) => _accountService = accountService;

    [HttpGet]
    public IActionResult Get() => Ok(_accountService.GetAll());
}

