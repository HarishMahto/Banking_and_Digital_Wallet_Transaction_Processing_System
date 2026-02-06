using System.Collections.Generic;

namespace BankingDigitalWallet.Api.Models
{
    public class Currency
    {
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;

        // Navigation Properties
        public ICollection<WalletBalance>? WalletBalances { get; set; }
    }
}
