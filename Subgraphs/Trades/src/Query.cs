using FinTech.Models;

public class Query
{
    public Trade GetTrades() =>
        new()
        {
            TradeId = 1,
            AccountId = 1,
            Symbol = "goo",
            Amount = 100
        };
}
