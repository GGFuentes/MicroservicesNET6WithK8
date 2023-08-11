using Microsoft.EntityFrameworkCore;
using MS.AFORO255.Notification.Models;

namespace MS.AFORO255.Notification.Persistences
{
    public class ContextDatabase : DbContext
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {
        }

        public DbSet<SendMailModel> SendMail => Set<SendMailModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SendMailModel>().ToTable("SendMail");
        }
    }
}
