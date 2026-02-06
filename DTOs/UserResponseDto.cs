using System;

namespace BankingDigitalWallet.Api.DTOs
{
    public class UserResponseDto
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public Guid WalletId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
