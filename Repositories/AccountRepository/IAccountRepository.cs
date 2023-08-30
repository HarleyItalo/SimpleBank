using SimpleBank.Models;

namespace SimpleBank.Repositories.AccountRepository
{
    public interface IAccountRepository
    {
        public Task<Account?> GetAccountById(int id);
    }
}