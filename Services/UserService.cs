using BankingDigitalWallet.Api.Data;
using BankingDigitalWallet.Api.DTOs;
using BankingDigitalWallet.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BankingDigitalWallet.Api.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserResponseDto> CreateAsync(CreateUserDto dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            var user = new User
            {
                Id = Guid.NewGuid(),
                FullName = dto.FullName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _context.Users.AddAsync(user);

            var wallet = new Wallet
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                CreatedAt = DateTime.UtcNow
            };

            await _context.Wallets.AddAsync(wallet);

            var walletBalance = new WalletBalance
            {
                Id = Guid.NewGuid(),
                WalletId = wallet.Id,
                CurrencyCode = "INR",
                Balance = 0,
                LastUpdatedAt = DateTime.UtcNow
            };

            await _context.WalletBalances.AddAsync(walletBalance);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return new UserResponseDto
            {
                UserId = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                WalletId = wallet.Id,
                CreatedAt = user.CreatedAt
            };
        }
    }
}
