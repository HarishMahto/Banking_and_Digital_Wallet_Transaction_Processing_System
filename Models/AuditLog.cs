using System;

namespace BankingDigitalWallet.Api.Models
{
    public class AuditLog
    {
        public Guid Id { get; set; }

        public string Action { get; set; } = default!;
        public string EntityName { get; set; } = default!;
        public Guid EntityId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
