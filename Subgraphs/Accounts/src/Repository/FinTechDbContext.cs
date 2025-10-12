using FinTech.Accounts.Models;
using Microsoft.EntityFrameworkCore;

namespace FinTech.Accounts.Repository;

public class FinTechDbContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Trade> Trades { get; set; }

    public FinTechDbContext(DbContextOptions<FinTechDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Account>().HasMany(c => c.Trades);
    }
}
