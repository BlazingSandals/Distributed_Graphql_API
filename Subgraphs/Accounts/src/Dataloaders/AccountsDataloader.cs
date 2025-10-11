using FinTech.Repository;
using Microsoft.EntityFrameworkCore;

namespace FinTech.Dataloaders;

public class AccountsDataLoader : BatchDataLoader<int, Models.Account>
{
    private readonly FinTechDbContext _context;

    public AccountsDataLoader(FinTechDbContext context, IBatchScheduler batchScheduler)
        : base(batchScheduler)
    {
        _context = context;
    }

    protected override async Task<IReadOnlyDictionary<int, Models.Account>> LoadBatchAsync(
        IReadOnlyList<int> keys,
        CancellationToken cancellationToken
    )
    {
        // This method will be called once with a batch of product IDs
        // to fetch all requested products in a single operation.
        return await _context
            .Accounts.Where(t => keys.Contains(t.AccountId))
            .ToDictionaryAsync(t => t.AccountId, cancellationToken);
    }
}

