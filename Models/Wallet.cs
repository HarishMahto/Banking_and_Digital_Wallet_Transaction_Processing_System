using System;
using System.Collections.Generic;

namespace BankingDigitalWallet.Api.Models
{
    public class Wallet
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public User? User { get; set; }

        public ICollection<Transaction>? Transactions { get; set; }

        public ICollection<WalletBalance>? WalletBalances { get; set; }

        public ICollection<LedgerEntry>? LedgerEntries { get; set; }
    }
}
