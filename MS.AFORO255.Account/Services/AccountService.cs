using Microsoft.EntityFrameworkCore;
using MS.AFORO255.Account.Persistences;

namespace MS.AFORO255.Account.Service;

public class AccountService : IAccountService
{
    private readonly ContextDatabase _contextDatabase;
    public AccountService(ContextDatabase contextDatabase) => _contextDatabase = contextDatabase;

    public bool Deposit(Models.Account account)
    {
        _contextDatabase.Account.Update(account);
        _contextDatabase.SaveChanges();
        return true;
    }

    public IEnumerable<Models.Account> GetAll() => _contextDatabase.Account.Include(x => x.Customer)
            .AsNoTracking().ToList();

    public bool Withdrawal(Models.Account account)
    {
        _contextDatabase.Account.Update(account);
        _contextDatabase.SaveChanges();
        return true;
    }
}

