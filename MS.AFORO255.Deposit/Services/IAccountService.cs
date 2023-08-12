using MS.AFORO255.Deposit.DTOs;
using MS.AFORO255.Deposit.Models;

namespace MS.AFORO255.Deposit.Services;

public interface IAccountService
{
    Task<bool> DepositAccount(AccountRequest request);
    bool DepositReverse(TransactionModel request);
    bool Execute(TransactionModel request);
}

