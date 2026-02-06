using System.Collections.Generic;

namespace BankingDigitalWallet.Api.Models
{
    public class TransactionType
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public ICollection<Transaction>? Transactions { get; set; }
    }
}
