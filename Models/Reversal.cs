using System;

namespace BankingDigitalWallet.Api.Models
{
    public class Reversal
    {
        public Guid Id { get; set; }

        public Guid OriginalTransactionId { get; set; }
        public Guid ReversalTransactionId { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public Transaction? OriginalTransaction { get; set; }
        public Transaction? ReversalTransaction { get; set; }
    }
}
