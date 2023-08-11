using Microsoft.EntityFrameworkCore;

namespace MS.AFORO255.Account.Persistences;

public class ContextDatabase : DbContext
{
    public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
    {
    }

    public DbSet<Models.Account> Account => Set<Models.Account>();
    public DbSet<Models.Customer> Customer => Set<Models.Customer>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Account>().ToTable("Account");
        modelBuilder.Entity<Models.Customer>().ToTable("Customer");
    }
}

