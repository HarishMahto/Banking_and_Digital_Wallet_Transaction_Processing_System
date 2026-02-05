using BankingDigitalWallet.Api.Models;
using System.Transactions;

public class Transaction
{
    public Guid Id { get; set; }

    public Guid WalletId { get; set; }
    public decimal Amount { get; set; }
    public string CurrencyCode { get; set; } = default!;

    public int TransactionTypeId { get; set; }
    public int TransactionStatusId { get; set; }

    public DateTime CreatedAt { get; set; }

    // Navigation Properties
    public Wallet? Wallet { get; set; }
    public TransactionType? TransactionType { get; set; }
    public TransactionStatus? TransactionStatus { get; set; }
    public ICollection<LedgerEntry>? LedgerEntries { get; set; }
    public ICollection<Dispute>? Disputes { get; set; }
}
