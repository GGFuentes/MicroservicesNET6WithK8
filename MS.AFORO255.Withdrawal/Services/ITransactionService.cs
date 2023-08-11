using MS.AFORO255.Withdrawal.Models;

namespace MS.AFORO255.Withdrawal.Services;

public interface ITransactionService
{
    TransactionModel Withdrawal(TransactionModel transaction);
    TransactionModel WithdrawalReverse(TransactionModel transaction);
}

