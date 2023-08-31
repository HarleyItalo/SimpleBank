using SimpleBank.Models;
using SimpleBank.Repositories.AccountRepository;
using SimpleBank.Usercases.CreateCreditTransaction;
using SimpleBank.Usercases.GetAccountById;
using SimpleBank.ViewModels;

namespace SimpleBank.Usercases.CreateAccount
{
    public class CreateAccountImpl : ICreateAccount
    {
        private readonly IAccountRepository _repository;
        private readonly ICreateCreditTransaction _createCreditTransaction;
        private readonly IGetAccountById _getAccountById;

        public CreateAccountImpl(
                        IAccountRepository repository,
                        ICreateCreditTransaction creditTransaction,
                        IGetAccountById getAccountById)
        {
            _repository = repository;
            _createCreditTransaction = creditTransaction;
            _getAccountById = getAccountById;
        }
        public async Task<AccountViewModel?> Create(CreateAccountViewModel createAccountViewModel)
        {
            var account = new Account(createAccountViewModel.Name, createAccountViewModel.LastName);
            var idAccount = await _repository.CreateAccount(account);

            if (idAccount == 0 && createAccountViewModel.InitialBalance <= 0)
                return null;

            var result = await _createCreditTransaction.Create(
                new TransactionViewModel
                {
                    AccountId = idAccount,
                    Value = createAccountViewModel.InitialBalance
                }
                );
            if (result.Item1 == false)
            {
                return null;
            }
            var response = await _getAccountById.GetAccount(idAccount);
            return response.Item2;
        }
    }
}