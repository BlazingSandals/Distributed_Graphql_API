using Microsoft.EntityFrameworkCore; 
using FinTech.Models;

namespace FinTech.Repository;

public class FinTechDbContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Trade> Trades { get; set; }

    public FinTechDbContext(DbContextOptions<FinTechDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>().HasMany(c => c.Trades);
    }
}
