using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleBank.Repositories.TransactionRepository;

namespace SimpleBank.Usercases.GetBalanceFromAccountId
{
    public class GetBalanceFromAccountIdImpl : IGetBalanceFromAccountId
    {
        private readonly ITransactionRepository _repository;
        public GetBalanceFromAccountIdImpl(ITransactionRepository repository)
        {
            _repository = repository;
        }
        public async Task<double> GetBalance(int accountId)
        {
            var response = await _repository.CalculateBalanceFromUser(accountId);
            return response;   
        }
    }
}