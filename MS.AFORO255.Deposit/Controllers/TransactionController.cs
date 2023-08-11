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
        public readonly IEventBus _eventeBus;

        public TransactionController(ITransactionService transactionService,IEventBus eventBus)
        {
            _transactionService = transactionService;
            _eventeBus = eventBus;
        }
           

        [HttpPost("Deposit")]
        public IActionResult Deposit([FromBody] TransactionRequest request)
        {
            TransactionModel transaction = new TransactionModel(request.Amount, request.AccountId);
            transaction = _transactionService.Deposit(transaction);

            _eventeBus.SendCommand(new TransactionCreateCommand(transaction.Id, transaction.Amount, transaction.Type, transaction.CreationDate
                , transaction.AccountId));

            return Ok(transaction);
        }
    }
}
