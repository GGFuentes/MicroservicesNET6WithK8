using MS.AFORO255.Deposit.Models;

namespace MS.AFORO255.Deposit.Services;

public interface ITransactionService
{
    TransactionModel Deposit(TransactionModel transaction);
    TransactionModel DepositReverse(TransactionModel transaction);
}

