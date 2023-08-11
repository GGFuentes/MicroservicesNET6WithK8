using Aforo255.Cross.Event.Src.Bus;
using MS.AFORO255.History.Features.Models;
using MS.AFORO255.History.Features.Services;
using MS.AFORO255.History.Messages.Events;
 
namespace MS.AFORO255.History.Messages.EventHandlers
{
    public class TransactionEventHandler : IEventHandler<TransactionCreatedEvent>
    {
        private readonly IHistoryService _historyService;
 
        public TransactionEventHandler(IHistoryService historyService) => _historyService = historyService;
 
        public Task Handle(TransactionCreatedEvent @event)
        {
            _historyService.Add(new HistoryModel()
            {
                IdTransaction = @event.transactionId,
                Amount = @event.Amount,
                Type = @event.Type,
                CreationDate = @event.CreationDate,
                AccountId = @event.AccountId
            });
            return Task.CompletedTask;
        }
    }
 
}