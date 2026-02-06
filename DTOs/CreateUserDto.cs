using System.ComponentModel.DataAnnotations;

namespace BankingDigitalWallet.Api.DTOs
{
    public class CreateUserDto
    {
        [Required]
        public string FullName { get; set; } = default!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;

        [Required]
        public string PhoneNumber { get; set; } = default!;
    }
}
