using SimpleBank.Models;
using SimpleBank.Repositories.AccountRepository;

namespace SimpleBank.Usercases.GetAccountById
{
    public class GetAccountByIdImpl : IGetAccountById
    {
        private readonly IAccountRepository _repository;
        public GetAccountByIdImpl(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<Account?> GetAccount(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var account = await _repository.GetAccountById(id);
            return account;
        }
    }
}