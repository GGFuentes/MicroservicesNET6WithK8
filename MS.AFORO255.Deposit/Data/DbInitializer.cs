using MS.AFORO255.Deposit.Persistences;

namespace MS.AFORO255.Deposit.Data
{
    public class DbInitializer
    {
        public static void Initialize(ContextDatabase context)
        {
            context.Database.EnsureCreated();
            context.SaveChanges();
        }
    }
}
