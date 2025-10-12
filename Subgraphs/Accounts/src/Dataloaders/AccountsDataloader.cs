using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinTech.Accounts.Models;
using FinTech.Accounts.Repository;
using Microsoft.EntityFrameworkCore;

namespace FinTech.Accounts.Dataloaders;

public class AccountsDataLoader
{
    private readonly FinTechDbContext _context;

    public AccountsDataLoader(FinTechDbContext context, IBatchScheduler batchScheduler)
        : base(batchScheduler)
    {
        _context = context;
    }

    [DataLoader]
    protected override async Task<ILookup<int, Account>> LoadGroupedBatchAsync(
        IReadOnlyList<int> keys,
        CancellationToken cancellationToken
    )
    {
        // This method will be called once with a batch of product IDs
        // to fetch all requested products in a single operation.
        var result = await _context
            .Accounts.Where(t => keys.Contains(t.AccountId))
            .ToListAsync(cancellationToken);

        return result.ToLookup(t => t.AccountId);
    }
}
