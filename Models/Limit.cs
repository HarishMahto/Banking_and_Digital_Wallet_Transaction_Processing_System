using System;

namespace BankingDigitalWallet.Api.Models
{
    public class Limit
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public decimal DailyLimit { get; set; }

        public User? User { get; set; }
    }
}
