using BankingDigitalWallet.Api.Data;
using BankingDigitalWallet.Api.DTOs;
using BankingDigitalWallet.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BankingDigitalWallet.Api.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ApplicationDbContext _context;

        public TransactionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TransactionResponseDto> ProcessAsync(CreateTransactionDto request)
        {
            var wallet = await _context.Wallets
                .Include(w => w.WalletBalances)
                .FirstOrDefaultAsync(w => w.Id == request.WalletId);

            if (wallet == null)
                throw new Exception("Wallet not found");

            int transactionTypeId = request.Type.ToLower() switch
            {
                "deposit" => 1,
                "withdraw" => 2,
                "transfer" => 3,
                _ => throw new Exception("Invalid transaction type")
            };

            int transactionStatusId = 2; // Completed

            if (request.Type.ToLower() == "deposit")
            {
                var balance = await GetOrCreateBalance(wallet.Id, request.CurrencyCode);
                balance.Balance += request.Amount;
            }
            else if (request.Type.ToLower() == "withdraw")
            {
                var balance = await GetOrCreateBalance(wallet.Id, request.CurrencyCode);

                if (balance.Balance < request.Amount)
                    throw new Exception("Insufficient balance");

                balance.Balance -= request.Amount;
            }
            else if (request.Type.ToLower() == "transfer")
            {
                if (request.ToWalletId == null)
                    throw new Exception("Destination wallet required");

                var targetWallet = await _context.Wallets
                    .FirstOrDefaultAsync(w => w.Id == request.ToWalletId);

                if (targetWallet == null)
                    throw new Exception("Target wallet not found");

                var sourceBalance = await GetOrCreateBalance(wallet.Id, request.CurrencyCode);

                if (sourceBalance.Balance < request.Amount)
                    throw new Exception("Insufficient balance");

                var targetBalance = await GetOrCreateBalance(targetWallet.Id, request.CurrencyCode);

                sourceBalance.Balance -= request.Amount;
                targetBalance.Balance += request.Amount;
            }

            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                WalletId = wallet.Id,
                Amount = request.Amount,
                CurrencyCode = request.CurrencyCode,
                TransactionTypeId = transactionTypeId,
                TransactionStatusId = transactionStatusId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Transactions.Add(transaction);

            await _context.SaveChangesAsync();

            return new TransactionResponseDto
            {
                TransactionId = transaction.Id,
                WalletId = wallet.Id,
                Amount = transaction.Amount,
                Type = request.Type,
                Status = "Completed",
                CreatedAt = transaction.CreatedAt
            };
        }

        private async Task<WalletBalance> GetOrCreateBalance(Guid walletId, string currencyCode)
        {
            var balance = await _context.WalletBalances
                .FirstOrDefaultAsync(b => b.WalletId == walletId && b.CurrencyCode == currencyCode);

            if (balance == null)
            {
                balance = new WalletBalance
                {
                    Id = Guid.NewGuid(),
                    WalletId = walletId,
                    CurrencyCode = currencyCode,
                    Balance = 0
                };

                _context.WalletBalances.Add(balance);
            }

            return balance;
        }
    }
}
