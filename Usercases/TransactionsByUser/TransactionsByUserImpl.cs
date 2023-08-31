

using SimpleBank.Models;
using SimpleBank.Repositories.TransactionRepository;

namespace SimpleBank.Usercases.TransactionsByUser
{
    public class TransactionsByUserImpl : ITransactionsByUser
    {
        private readonly ITransactionRepository _repository;

        public TransactionsByUserImpl(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Transaction>?> Get(int accountId)
        {
          return await _repository.GetAllTransactionByUserID(accountId);
        }
    }
}