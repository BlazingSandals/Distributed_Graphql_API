using FinTech.Trades.Models;
using Microsoft.EntityFrameworkCore;

namespace FinTech.Trades.Repository;

public class FinTechDbContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Trade> Trades { get; set; }

    public FinTechDbContext(DbContextOptions<FinTechDbContext> options)
        : base(options) { }

}
