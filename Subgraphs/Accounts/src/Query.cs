using FinTech.Dataloaders;
using FinTech.Models;

namespace FinTech;

public class Query
{
    public async Task<Account> GetAccountById(
        string id,
        AccountsDataLoader accountsDataLoader,
        CancellationToken cancellationToken
    )
    {
        // The DataLoader will batch multiple calls to LoadAsync for the same product IDs
        // into a single call to LoadBatchAsync in ProductDataLoader.
        var result = await accountsDataLoader.LoadAsync(id, cancellationToken);
        return null;
    }

    // public async Task<Account?> GetAccountsIdAsync(
    //     string id,
    //      [DataLoader] GetAccountsByIdAsync (productById,
    //     CancellationToken cancellationToken)
    //         => await productById.LoadAsync(id, cancellationToken);
}
