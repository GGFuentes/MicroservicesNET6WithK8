namespace MS.AFORO255.Deposit.DTOs;

public class AccountRequest
{
    public AccountRequest(int accountId, decimal amount)
    {
        AccountId = accountId;
        Amount = amount;
    }

    public int AccountId { get; set; }
    public decimal Amount { get; set; }

}

