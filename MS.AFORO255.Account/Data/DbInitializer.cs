using MS.AFORO255.Account.Persistences;

namespace MS.AFORO255.Account.Data;

public class DbInitializer
{
    public static void Initialize(ContextDatabase context)
    {
        context.Database.EnsureCreated();

        if (context.Customer.Any()) return;

        var customers = new Models.Customer[]
        {
                new Models.Customer{CustomerId=1,FullName="Renato Tapia",Email="rtapia@aforo255.com"},
                new Models.Customer{CustomerId=2,FullName="Leonel Messis",Email="lmessi@aforo255.com"},
                new Models.Customer{CustomerId=3,FullName="Paolo Guerrero",Email="pguerrero@aforo255.com"},
                new Models.Customer{CustomerId=4,FullName="Andrea Pirlo",Email="apirlo@aforo255.com"}
        };

        foreach (Models.Customer s in customers)
        {
            context.Customer.Add(s);
        }

        if (context.Account.Any()) return;

        var accounts = new Models.Account[]
        {
                new Models.Account{AccountId=1,TotalAmount=1000,CustomerId=1},
                new Models.Account{AccountId=2,TotalAmount=5000,CustomerId=2},
                new Models.Account{AccountId=3,TotalAmount=2000,CustomerId=4},
                new Models.Account{AccountId=4,TotalAmount=3000,CustomerId=1},
                new Models.Account{AccountId=5,TotalAmount=6000,CustomerId=3},
                new Models.Account{AccountId=6,TotalAmount=500,CustomerId=3},
                new Models.Account{AccountId=7,TotalAmount=800,CustomerId=1},
                new Models.Account{AccountId=8,TotalAmount=100,CustomerId=4},
                new Models.Account{AccountId=9,TotalAmount=20,CustomerId=2},
                new Models.Account{AccountId=10,TotalAmount=1000,CustomerId=3}
        };

        foreach (Models.Account s in accounts)
        {
            context.Account.Add(s);
        }
        context.SaveChanges();
    }
}

