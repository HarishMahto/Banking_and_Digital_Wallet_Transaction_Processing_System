using Microsoft.EntityFrameworkCore;
using BankingDigitalWallet.Api.Models;

namespace BankingDigitalWallet.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Wallet> Wallets => Set<Wallet>();
        public DbSet<WalletBalance> WalletBalances => Set<WalletBalance>();
        public DbSet<Transaction> Transactions => Set<Transaction>();
        public DbSet<LedgerEntry> LedgerEntries => Set<LedgerEntry>();
        public DbSet<Reversal> Reversals => Set<Reversal>();
        public DbSet<Dispute> Disputes => Set<Dispute>();
        public DbSet<KYCRequest> KYCRequests => Set<KYCRequest>();
        public DbSet<TransactionType> TransactionTypes => Set<TransactionType>();
        public DbSet<TransactionStatus> TransactionStatuses => Set<TransactionStatus>();
        public DbSet<KYCStatus> KYCStatuses => Set<KYCStatus>();
        public DbSet<Currency> Currencies => Set<Currency>();
        public DbSet<Limit> Limits => Set<Limit>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ===============================
            // PRIMARY KEYS
            // ===============================

            modelBuilder.Entity<Currency>()
                .HasKey(c => c.Code);

            // ===============================
            // DECIMAL PRECISION
            // ===============================

            modelBuilder.Entity<WalletBalance>()
                .Property(wb => wb.Balance)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<LedgerEntry>()
                .Property(le => le.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Limit>()
                .Property(l => l.DailyLimit)
                .HasPrecision(18, 2);

            // ===============================
            // RELATIONSHIPS
            // ===============================

            // Wallet → User
            modelBuilder.Entity<Wallet>()
                .HasOne(w => w.User)
                .WithMany(u => u.Wallets)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Transaction → Wallet
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Wallet)
                .WithMany(w => w.Transactions)
                .HasForeignKey(t => t.WalletId)
                .OnDelete(DeleteBehavior.Restrict);

            // LedgerEntry → Transaction
            modelBuilder.Entity<LedgerEntry>()
                .HasOne(le => le.Transaction)
                .WithMany(t => t.LedgerEntries)
                .HasForeignKey(le => le.TransactionId)
                .OnDelete(DeleteBehavior.Restrict);

            // LedgerEntry → Wallet
            modelBuilder.Entity<LedgerEntry>()
                .HasOne(le => le.Wallet)
                .WithMany(w => w.LedgerEntries)
                .HasForeignKey(le => le.WalletId)
                .OnDelete(DeleteBehavior.Restrict);

            // Reversal self-reference FIXED
            modelBuilder.Entity<Reversal>()
                .HasOne(r => r.OriginalTransaction)
                .WithMany()
                .HasForeignKey(r => r.OriginalTransactionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reversal>()
                .HasOne(r => r.ReversalTransaction)
                .WithMany()
                .HasForeignKey(r => r.ReversalTransactionId)
                .OnDelete(DeleteBehavior.Restrict);

            // WalletBalance → Wallet
            modelBuilder.Entity<WalletBalance>()
                .HasOne(wb => wb.Wallet)
                .WithMany(w => w.WalletBalances)
                .HasForeignKey(wb => wb.WalletId)
                .OnDelete(DeleteBehavior.Cascade);

            // WalletBalance → Currency
            modelBuilder.Entity<WalletBalance>()
                .HasOne(wb => wb.Currency)
                .WithMany(c => c.WalletBalances)
                .HasForeignKey(wb => wb.CurrencyCode)
                .OnDelete(DeleteBehavior.Restrict);

            // ===============================
            // MASTER DATA SEEDING
            // ===============================

            modelBuilder.Entity<TransactionType>().HasData(
                new TransactionType { Id = 1, Name = "Deposit" },
                new TransactionType { Id = 2, Name = "Withdraw" },
                new TransactionType { Id = 3, Name = "Transfer" },
                new TransactionType { Id = 4, Name = "Reversal" }
            );

            modelBuilder.Entity<TransactionStatus>().HasData(
                new TransactionStatus { Id = 1, Name = "Pending" },
                new TransactionStatus { Id = 2, Name = "Completed" },
                new TransactionStatus { Id = 3, Name = "Failed" }
            );

            modelBuilder.Entity<KYCStatus>().HasData(
                new KYCStatus { Id = 1, Name = "Pending" },
                new KYCStatus { Id = 2, Name = "Approved" },
                new KYCStatus { Id = 3, Name = "Rejected" }
            );

            modelBuilder.Entity<Currency>().HasData(
                new Currency { Code = "USD", Name = "US Dollar" },
                new Currency { Code = "INR", Name = "Indian Rupee" },
                new Currency { Code = "EUR", Name = "Euro" }
            );
        }
    }
}
