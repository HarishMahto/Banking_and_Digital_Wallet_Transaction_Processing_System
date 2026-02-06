using System;
using System.Collections.Generic;

namespace BankingDigitalWallet.Api.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public ICollection<Wallet>? Wallets { get; set; }
        public ICollection<KYCRequest>? KYCRequests { get; set; }
        public ICollection<Beneficiary>? Beneficiaries { get; set; }
        public ICollection<Limit>? Limits { get; set; }
        public ICollection<Notification>? Notifications { get; set; }
    }
}
