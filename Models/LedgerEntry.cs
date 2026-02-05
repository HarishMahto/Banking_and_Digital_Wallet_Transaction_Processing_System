public class LedgerEntry
{
    public Guid Id { get; set; }

    public Guid TransactionId { get; set; }
    public Guid WalletId { get; set; }

    public decimal Amount { get; set; }
    public string EntryType { get; set; } = default!; // Debit / Credit

    public DateTime CreatedAt { get; set; }

    // Navigation Properties
    public Transaction? Transaction { get; set; }
    public Wallet? Wallet { get; set; }
}
