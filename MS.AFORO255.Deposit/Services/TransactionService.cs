using MS.AFORO255.Deposit.Models;
using MS.AFORO255.Deposit.Persistences;

namespace MS.AFORO255.Deposit.Services;

public class TransactionService : ITransactionService
{
    private readonly ContextDatabase _contextDatabase;

    public TransactionService(ContextDatabase contextDatabase) => _contextDatabase = contextDatabase;

    public TransactionModel Deposit(TransactionModel transaction)
    {
        _contextDatabase.Transaction.Add(transaction);
        _contextDatabase.SaveChanges();
        return transaction;
    }

    public TransactionModel DepositReverse(TransactionModel transaction)
    {
        _contextDatabase.Transaction.Add(transaction);
        _contextDatabase.SaveChanges();
        return transaction;
    }
}

