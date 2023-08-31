using SimpleBank.Constants;
using SimpleBank.Models;
using SimpleBank.Repositories.AccountRepository;
using SimpleBank.ViewModels;

namespace SimpleBank.Usercases.GetAccountById
{
    public class GetAccountByIdImpl : IGetAccountById
    {
        private readonly IAccountRepository _repository;
        public GetAccountByIdImpl(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<Tuple<bool, AccountViewModel?>> GetAccount(int accountId)
        {
            if (accountId == 0)
            {
                return new (false,null);
            }
            var account = await _repository.GetAccountById(accountId);
            return new(true, new AccountViewModel(200,Messages.REQUEST_OK,account));
        }
    }
}