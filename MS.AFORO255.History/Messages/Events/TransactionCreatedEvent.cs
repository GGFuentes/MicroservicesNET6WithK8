using Aforo255.Cross.Event.Src.Events;

namespace MS.AFORO255.History.Messages.Events
{
    public class TransactionCreatedEvent : Event
    {
        public TransactionCreatedEvent(int transactionId, decimal amount, string? type, string? creationDate, int accountId)
        {
            this.transactionId = transactionId;
            Amount = amount;
            Type = type;
            CreationDate = creationDate;
            AccountId = accountId;
        }

        public int transactionId { get; set; }
        public decimal Amount { get; set; }
        public string? Type { get; set; }
        public string? CreationDate { get; set; }
        public int AccountId { get; set; }
    }

}

