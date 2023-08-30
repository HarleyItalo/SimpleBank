using SimpleBank.Models;
using SimpleBank.Repositories.AccountRepository;

namespace SimpleBank.Usercases.GetAccountById
{
    public class GetAccountByIdImpl : IGetAccountById
    {
        private readonly IAccountRepository repository;
        public GetAccountByIdImpl(IAccountRepository _repository)
        {
            repository = _repository;
        }

        public async Task<Account?> GetAccount(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var account = await repository.GetAccountById(id);
            return account;
        }
    }
}