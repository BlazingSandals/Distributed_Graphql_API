namespace FinTech.Accounts.Models;

public class Trade
{
    public required int TradeId { get; set; }
    public required int AccountId { get; set; }
    public required string Symbol { get; set; }
    public required int Amount { get; set; }
}