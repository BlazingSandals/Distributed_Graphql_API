using FinTech.Accounts.Dataloaders;
using FinTech.Accounts.Models;
using FinTech.Accounts.Repository;
using System.Collections;

internal static class ProductDataLoader
{
    [DataLoader]
    public static async Task<Dictionary<int, Account>> GetProductByIdAsync(
        IReadOnlyList<int> productIds,
        FinTechDbContext context,
        CancellationToken cancellationToken)
        => await context.Accounts
            .Where(t => productIds.Contains(t.AccountId))
            .ToDictionaryAsync(t => t.Id, cancellationToken);
}

public class Query
{
    public async Task<Account?> GetProductByIdAsync(
        string id,
        GetProductByIdAsync productById,
        CancellationToken cancellationToken)
        => await productById.LoadAsync(id, cancellationToken);
}






// public class Query
// {
//     public async Task<Account?> GetAccountById(
//         string id,
//         AccountsDataLoader accountsDataLoader,
//         CancellationToken cancellationToken
//     )
//     {
//         // The DataLoader will batch multiple calls to LoadAsync for the same product IDs
//         // into a single call to LoadBatchAsync in ProductDataLoader.
//         return await accountsDataLoader.LoadAsync(id, cancellationToken);
//     }
// }
