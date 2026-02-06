using System;

namespace BankingDigitalWallet.Api.Models
{
    public class ComplianceRule
    {
        public Guid Id { get; set; }

        public string RuleName { get; set; } = default!;
        public string Description { get; set; } = default!;
        public bool IsActive { get; set; }
    }
}
