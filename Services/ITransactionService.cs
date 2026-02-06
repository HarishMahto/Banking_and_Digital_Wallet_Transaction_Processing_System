using BankingDigitalWallet.Api.DTOs;
using System.Threading.Tasks;

namespace BankingDigitalWallet.Api.Services
{
    public interface ITransactionService
    {
        Task<TransactionResponseDto> ProcessAsync(CreateTransactionDto request);
    }
}
