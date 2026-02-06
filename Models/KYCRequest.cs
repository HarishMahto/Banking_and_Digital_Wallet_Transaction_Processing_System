using System;

namespace BankingDigitalWallet.Api.Models
{
    public class KYCRequest
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public int KYCStatusId { get; set; }

        public string DocumentType { get; set; } = default!;
        public string DocumentNumber { get; set; } = default!;

        public DateTime CreatedAt { get; set; }

        public User? User { get; set; }
        public KYCStatus? KYCStatus { get; set; }
    }
}

