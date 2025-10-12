using FinTech.Trades.Repository;
using Microsoft.EntityFrameworkCore;

namespace FinTech.Trades.Dataloaders;

public class TradesDataLoader : BatchDataLoader<int, Models.Trade>
{
    private readonly FinTechDbContext _context;

    public TradesDataLoader(FinTechDbContext context, IBatchScheduler batchScheduler)
        : base(batchScheduler)
    {
        _context = context;
    }

    protected override async Task<IReadOnlyDictionary<int, Models.Trade>> LoadBatchAsync(
        IReadOnlyList<int> keys,
        CancellationToken cancellationToken
    )
    {
        // This method will be called once with a batch of product IDs
        // to fetch all requested products in a single operation.
        return await _context
            .Trades.Where(t => keys.Contains(t.TradeId))
            .ToDictionaryAsync(t => t.TradeId, cancellationToken);
    }
}
