using SimpleBank.Models;
using SimpleBank.ViewModels;

namespace SimpleBank.Usercases.CreateCreditTransaction
{
    public interface ICreateCreditTransaction
    {
        public Task<Tuple<bool,string>> Create(TransactionViewModel transaction);
    }
}