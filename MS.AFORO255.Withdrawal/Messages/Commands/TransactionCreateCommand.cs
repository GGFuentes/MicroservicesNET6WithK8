using Aforo255.Cross.Event.Src.Commands;

namespace MS.AFORO255.Withdrawal.Messages.Commands
{
    public class TransactionCreateCommand : Command
    {
        public int TransactionId { get; protected set; }
        public decimal Amount { get; protected set; }
        public string? Type { get; protected set; }
        public string? CreationDate { get; protected set; }
        public int AccountId { get; protected set; }

        public TransactionCreateCommand(int transactionId, decimal amount, string? type, string? creationDate, int accountId)
        {
            TransactionId = transactionId;
            Amount = amount;
            Type = type;
            CreationDate = creationDate;
            AccountId = accountId;
        }
    }
}
