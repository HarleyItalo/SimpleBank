using SimpleBank.Context;
using SimpleBank.Models;

namespace SimpleBank.Repositories.AccountRepository
{
    public class AccountRepository : IAccountRepository
    {
        protected SimpleBankDbContext simpleBankDbContext;
        public AccountRepository(SimpleBankDbContext context)
        {
            simpleBankDbContext = context;
        }
        public Task<Account?> GetAccountById(int id)
        {
            var account = simpleBankDbContext.Accounts?.FirstOrDefault(i => i.AccoutId == id);
            return Task.FromResult(account);
        }
    }
}