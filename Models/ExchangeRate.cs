using System;

namespace BankingDigitalWallet.Api.Models
{
    public class ExchangeRate
    {
        public Guid Id { get; set; }

        public string FromCurrency { get; set; } = default!;
        public string ToCurrency { get; set; } = default!;
        public decimal Rate { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
