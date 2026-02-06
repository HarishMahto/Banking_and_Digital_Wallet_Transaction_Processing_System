using System;
using System.ComponentModel.DataAnnotations;

namespace BankingDigitalWallet.Api.DTOs
{
    public class CreateTransactionDto
    {
        [Required]
        public Guid WalletId { get; set; }

        public Guid? ToWalletId { get; set; }  // Required only for Transfer

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public string Type { get; set; } = string.Empty;
        // Deposit | Withdraw | Transfer

        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string CurrencyCode { get; set; } = string.Empty;
        // Example: "INR", "USD"
    }
}
