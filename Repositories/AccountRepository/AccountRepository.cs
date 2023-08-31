using SimpleBank.Context;
using SimpleBank.Models;
using SimpleBank.ViewModels;

namespace SimpleBank.Repositories.AccountRepository
{
    public class AccountRepository : IAccountRepository
    {
        protected SimpleBankDbContext simpleBankDbContext;
        public AccountRepository(SimpleBankDbContext context)
        {
            simpleBankDbContext = context;
        }

        public async Task<int> CreateAccount(Account createAccount)
        {
            if (simpleBankDbContext.Accounts != null)
                await simpleBankDbContext.Accounts.AddAsync(createAccount);

            var saved = await simpleBankDbContext.SaveChangesAsync() > 0;
            if (saved)
                return createAccount.AccoutId;
            
            return 0;
        }

        public Task<Account?> GetAccountById(int id)
        {
            var account = simpleBankDbContext.Accounts?.FirstOrDefault(i => i.AccoutId == id);
            return Task.FromResult(account);
        }
    }
}