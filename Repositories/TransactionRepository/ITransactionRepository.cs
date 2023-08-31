using SimpleBank.Models;

namespace SimpleBank.Repositories.TransactionRepository
{
    public interface ITransactionRepository
    {
        public Task<bool> CreateTransaction(Transaction transaction);
        public Task<List<Transaction>?> GetAllTransactionByUserID(int accountId);

        public Task<double> CalculateBalanceFromUser(int accountId);
    }
}