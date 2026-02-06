using BankingDigitalWallet.Api.DTOs;
using BankingDigitalWallet.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankingDigitalWallet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _service;

        public TransactionController(ITransactionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Process(CreateTransactionDto request)
        {
            var result = await _service.ProcessAsync(request);
            return Ok(result);
        }
    }
}
