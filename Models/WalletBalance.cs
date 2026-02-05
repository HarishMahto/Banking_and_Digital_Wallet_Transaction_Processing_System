using BankingDigitalWallet.Api.Models;

public class WalletBalance
{
    public Guid Id { get; set; }

    public Guid WalletId { get; set; }
    public string CurrencyCode { get; set; } = default!;
    public decimal Balance { get; set; }
    public DateTime LastUpdatedAt { get; set; }

    // Navigation Properties
    public Wallet? Wallet { get; set; }
    public Currency? Currency { get; set; }
}
