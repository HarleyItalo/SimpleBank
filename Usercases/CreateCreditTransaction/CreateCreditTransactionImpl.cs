using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleBank.Constants;
using SimpleBank.Models;
using SimpleBank.Repositories.TransactionRepository;
using SimpleBank.ViewModels;

namespace SimpleBank.Usercases.CreateCreditTransaction
{
    public class CreateCreditTransactionImpl : ICreateCreditTransaction
    {
        private readonly ITransactionRepository _repository;
        public CreateCreditTransactionImpl(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Tuple<bool, string>> Create(TransactionViewModel transactionViewModel)
        {
            var transaction = new Transaction
            {
                Value = transactionViewModel.Value,
                AccountId = transactionViewModel.AccountId,
                TransactionType = Models.ValueObjects.TransactionType.Credit
            };
            
            if (transaction.Value < 0)
                return new(false,Messages.TRANSACTION_NOT_AUTORIZATED_INVALID_VALUE);

            var response = await _repository.CreateTransaction(transaction);
            if(response)
                return new(true,Messages.TRANSACTION_SUCCESS);
            
            return new (false, Messages.DATABASE_ERROR);
        }
    }
}