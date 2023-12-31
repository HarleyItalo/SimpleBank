using Microsoft.EntityFrameworkCore;
using SimpleBank.Context;
using SimpleBank.Models;

namespace SimpleBank.Repositories.TransactionRepository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly SimpleBankDbContext simpleBankDbContext;
        public TransactionRepository(SimpleBankDbContext context)
        {
            simpleBankDbContext = context;
        }
        public async Task<double> CalculateBalanceFromUser(int accountId)
        {
            if (simpleBankDbContext.Transactions == null)
            {
                return 0.0;
            }
            var balance = await simpleBankDbContext.Transactions
                                    .Where(i => i.AccountId == accountId)
                                    .SumAsync(s => s.Value);
            return balance;
        }

        public async Task<bool> CreateTransaction(Transaction transaction)
        {
            if (simpleBankDbContext.Transactions == null)
            {
                return false;
            }
            await simpleBankDbContext.Transactions!.AddAsync(transaction);
            return await simpleBankDbContext.SaveChangesAsync() > 0;
        }

        public async Task<List<Transaction>?> GetAllTransactionByUserID(int accountId)
        {
            var result = simpleBankDbContext.Transactions
                                ?.Where(i => i.AccountId == accountId);
            if (result == null)
            {
                return null;
            }
            return await result.ToListAsync();
        }
    }
}