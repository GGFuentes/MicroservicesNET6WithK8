using MS.AFORO255.Security.Persistences;

namespace MS.AFORO255.Security.Data;

public class DbInitializer
{
    public static void Initialize(ContextDatabase context)
    {
        context.Database.EnsureCreated();

        if (context.Access.Any()) return;

        var orders = new Models.Access[]
        {
                new Models.Access{Fullname="Usuario Aforo255",Username="aforo255",Password="123456"},
                new Models.Access{Fullname="Juan Perez",Username="jperez",Password="654321"},
                new Models.Access{Fullname="Leonel Messi",Username="lmessi",Password="123"},
        };
        foreach (Models.Access s in orders)
        {
            context.Access.Add(s);
        }
        context.SaveChanges();
    }
}

