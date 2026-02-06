using BankingDigitalWallet.Api.Data;
using BankingDigitalWallet.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BankingDigitalWallet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WalletController(ApplicationDbContext context)
        {
            _context = context;
        }

        // CREATE WALLET
        [HttpPost]
        public async Task<IActionResult> CreateWallet([FromQuery] Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return NotFound("User not found");

            var wallet = new Wallet
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Wallets.Add(wallet);
            await _context.SaveChangesAsync();

            var response = new
            {
                wallet.Id,
                wallet.UserId,
                wallet.CreatedAt
            };

            return Ok(response);
        }

        // GET WALLET WITH BALANCES
        [HttpGet("{walletId}")]
        public async Task<IActionResult> GetWallet(Guid walletId)
        {
            var wallet = await _context.Wallets
                .Include(w => w.WalletBalances)
                .FirstOrDefaultAsync(w => w.Id == walletId);

            if (wallet == null)
                return NotFound("Wallet not found");

            var response = new
            {
                wallet.Id,
                wallet.UserId,
                wallet.CreatedAt,
                Balances = wallet.WalletBalances?.Select(b => new
                {
                    b.CurrencyCode,
                    b.Balance
                })
            };

            return Ok(response);
        }
    }
}
