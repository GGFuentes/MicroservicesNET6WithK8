using MS.AFORO255.Withdrawal.DTOs;
using MS.AFORO255.Withdrawal.Models;

namespace MS.AFORO255.Withdrawal.Services;

public interface IAccountService
{
    Task<bool> WithdrawalAccount(AccountRequest request);
    bool WithdrawalReverse(TransactionModel request);
    bool Execute(TransactionModel request);
}
