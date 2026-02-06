using System.Collections.Generic;

namespace BankingDigitalWallet.Api.Models
{
    public class KYCStatus
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public ICollection<KYCRequest>? KYCRequests { get; set; }
    }
}
