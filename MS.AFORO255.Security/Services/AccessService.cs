using MS.AFORO255.Security.Models;
using MS.AFORO255.Security.Persistences;

namespace MS.AFORO255.Security.Services;
public class AccessService : IAccessService
{
    private readonly ContextDatabase _contextDatabase;
    public AccessService(ContextDatabase contextDatabase) => _contextDatabase = contextDatabase;
    public IEnumerable<Access> GetAll() => _contextDatabase.Access.ToList();
    public bool Validate(string? userName, string? password)
    {
        var list = _contextDatabase.Access.ToList();
        var access = list.FirstOrDefault(x => x.Username == userName && x.Password == password);
        if (access is not null) return true;
        return false;
    }
}

