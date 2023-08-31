using SimpleBank.Models;
using SimpleBank.ViewModels;

namespace SimpleBank.Usercases.CreateAccount
{
    public interface ICreateAccount
    {
        public Task<AccountViewModel?>  Create(CreateAccountViewModel createAccountViewModel);
    }
}