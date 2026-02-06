using System;
using System.Collections.Generic;

namespace BankingDigitalWallet.Api.Models
{
    public class Dispute
    {
        public Guid Id { get; set; }

        public Guid TransactionId { get; set; }
        public string Reason { get; set; } = default!;

        public DateTime CreatedAt { get; set; }

        public Transaction? Transaction { get; set; }
        public ICollection<DisputeMessage>? Messages { get; set; }
    }
}
