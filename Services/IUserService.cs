using BankingDigitalWallet.Api.DTOs;
using System.Threading.Tasks;

namespace BankingDigitalWallet.Api.Services
{
    public interface IUserService
    {
        Task<UserResponseDto> CreateAsync(CreateUserDto dto);
    }
}
