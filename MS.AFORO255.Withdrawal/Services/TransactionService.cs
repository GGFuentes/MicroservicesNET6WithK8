using MS.AFORO255.Withdrawal.Models;
using MS.AFORO255.Withdrawal.Persistences;

namespace MS.AFORO255.Withdrawal.Services;

public class TransactionService : ITransactionService
{
    private readonly ContextDatabase _contextDatabase;

    public TransactionService(ContextDatabase contextDatabase) => _contextDatabase = contextDatabase;

    public TransactionModel Withdrawal(TransactionModel transaction)
    {
        _contextDatabase.Transaction.Add(transaction);
        _contextDatabase.SaveChanges();
        return transaction;
    }

    public TransactionModel WithdrawalReverse(TransactionModel transaction)
    {
        _contextDatabase.Transaction.Add(transaction);
        _contextDatabase.SaveChanges();
        return transaction;
    }
}

