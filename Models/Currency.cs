public class Currency
{
    public string Code { get; set; } = default!; // PK (INR, USD)
    public string Name { get; set; } = default!;

    // Navigation Properties
    public ICollection<WalletBalance>? WalletBalances { get; set; }
}
