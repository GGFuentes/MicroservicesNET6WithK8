using Microsoft.EntityFrameworkCore;
using MS.AFORO255.Deposit.Models;

namespace MS.AFORO255.Deposit.Persistences;

public class ContextDatabase : DbContext
{
    public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
    {
    }
    public DbSet<TransactionModel> Transaction => Set<TransactionModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.TransactionModel>().ToTable("Transaction");
    }
}

