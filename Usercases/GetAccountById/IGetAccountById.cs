using SimpleBank.ViewModels;

namespace SimpleBank.Usercases.GetAccountById
{
    public interface IGetAccountById
    {
        public Task<Tuple<bool, AccountViewModel?>> GetAccount(int accountId);
    }
}