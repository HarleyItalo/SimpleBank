using SimpleBank.Models;

namespace SimpleBank.ViewModels
{
    public class TransactionsByUserViewModel : BaseResponseViewModel
    {
        public List<Transaction> Transactions { get; set; }
        public TransactionsByUserViewModel(int status, string message, List<Transaction> transactions) : base(status, message)
        {
            Transactions = transactions;
        }
    }
}