using SimpleBank.Constants;
using SimpleBank.Models;
using SimpleBank.Repositories.TransactionRepository;
using SimpleBank.Usercases.GetBalanceFromAccountId;
using SimpleBank.ViewModels;

namespace SimpleBank.Usercases.CreateDebitTransaction
{
    public class CreateDebitTransactionImpl : ICreateDebitTransaction
    {
        private readonly ITransactionRepository _repository;
        private readonly IGetBalanceFromAccountId _balance;

        public CreateDebitTransactionImpl(ITransactionRepository repository,IGetBalanceFromAccountId getBalance)
        {
            _repository = repository;
            _balance = getBalance;
        }

        public async Task<Tuple<bool,string>> Create(TransactionViewModel transactionViewModel)
        {
            var transaction = new Transaction
            {
                AccountId = transactionViewModel.AccountId,
                Value = transactionViewModel.Value,
                TransactionType = Models.ValueObjects.TransactionType.Debit
            };

            var balance = await _balance.GetBalance(transaction.AccountId);
            if(balance < transaction.Value){
                return new (false,Messages.TRANSACTION_NOT_AUTORIZATED);
            }

            if (transaction.Value > 0)
                transaction.Value *= -1;
  
            return new(await _repository.CreateTransaction(transaction),Messages.TRANSACTION_SUCCESS);
        }
    }
}