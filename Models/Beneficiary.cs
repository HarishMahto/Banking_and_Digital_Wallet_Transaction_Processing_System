using System;

namespace BankingDigitalWallet.Api.Models
{
    public class Beneficiary
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public string Name { get; set; } = default!;
        public string BankAccount { get; set; } = default!;

        public DateTime CreatedAt { get; set; }

        public User? User { get; set; }
    }
}
