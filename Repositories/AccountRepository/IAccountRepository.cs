using SimpleBank.Models;
using SimpleBank.ViewModels;

namespace SimpleBank.Repositories.AccountRepository
{
    public interface IAccountRepository
    {
        public Task<Account?> GetAccountById(int id);
        public Task<int> CreateAccount(Account createAccount);
    }
}