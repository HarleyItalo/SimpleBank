using SimpleBank.ViewModels;

namespace SimpleBank.Usercases.CreateDebitTransaction
{
    public interface ICreateDebitTransaction
    {
        public Task<Tuple<bool,string>> Create(TransactionViewModel transaction);   
    }
}