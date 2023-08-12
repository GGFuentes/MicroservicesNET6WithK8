using Aforo255.Cross.Event.Src.Bus;
using Microsoft.AspNetCore.Mvc;
using MS.AFORO255.Deposit.DTOs;
using MS.AFORO255.Deposit.Messages.Commands;
using MS.AFORO255.Deposit.Models;
using MS.AFORO255.Deposit.Services;

namespace MS.AFORO255.Deposit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public readonly IEventBus _eventBus;
        private readonly IAccountService _accountService;

        public TransactionController(ITransactionService transactionService,IEventBus eventBus, IAccountService accountService)
        {
            _transactionService = transactionService;
            _eventBus = eventBus;
            _accountService = accountService;
        }
           

        [HttpPost("Deposit")]
        public IActionResult Deposit([FromBody] TransactionRequest request)
        {
            TransactionModel transaction = new TransactionModel(request.Amount, request.AccountId);
            transaction = _transactionService.Deposit(transaction);
            if (_accountService.Execute(transaction))
            {
                _eventBus.SendCommand(new TransactionCreateCommand(transaction.Id, transaction.Amount, transaction.Type, transaction.CreationDate
                , transaction.AccountId));

                _eventBus.SendCommand(new NotificationCreateCommand(transaction.Id, transaction.Amount, transaction.Type,
                          $"Se proceso el {transaction.Type} con el monto de {transaction.Amount} de su cuenta {transaction.AccountId}",
                          "servicedesk@aforo255.com", transaction.AccountId));
            }
            return Ok(transaction);
        }
    }
}
