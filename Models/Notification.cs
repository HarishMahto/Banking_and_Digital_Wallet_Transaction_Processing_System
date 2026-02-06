using System;

namespace BankingDigitalWallet.Api.Models
{
    public class Notification
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public string Message { get; set; } = default!;
        public bool IsRead { get; set; }

        public DateTime CreatedAt { get; set; }

        public User? User { get; set; }
    }
}
