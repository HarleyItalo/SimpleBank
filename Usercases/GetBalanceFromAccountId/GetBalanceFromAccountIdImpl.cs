using 
SimpleBank.Repositories.TransactionRepository;
using SimpleBank.Usercases.GetAccountById;

namespace SimpleBank.Usercases.GetBalanceFromAccountId
{
    public class GetBalanceFromAccountIdImpl : IGetBalanceFromAccountId
    {
        private readonly ITransactionRepository _repository;
            private readonly IGetAccountById _getAccountById;
        public GetBalanceFromAccountIdImpl(
                        ITransactionRepository repository,
                        IGetAccountById accountById)
        {
            _repository = repository;
                    _getAccountById = accountById;
            
        }
        public async Task<double> GetBalance(int accountId)
        {
            var response = await _repository.CalculateBalanceFromUser(accountId);
            return response;   
        }
    }
}