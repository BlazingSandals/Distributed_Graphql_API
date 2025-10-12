namespace FinTech.Accounts.Models;

public class Account
{
    public required int AccountId { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public List<Trade> Trades { get; set; } = new();
}
