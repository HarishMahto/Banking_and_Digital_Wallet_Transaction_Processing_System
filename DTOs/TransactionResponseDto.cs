using System;

namespace BankingDigitalWallet.Api.DTOs
{
    public class TransactionResponseDto
    {
        public Guid TransactionId { get; set; }
        public Guid WalletId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } = default!;
        public string Status { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
    }
}
