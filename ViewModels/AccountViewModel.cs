using SimpleBank.Models;

namespace SimpleBank.ViewModels
{
    public class AccountViewModel : BaseResponseViewModel
    {
        public Account? Account { get; set; }
        public AccountViewModel(int status, string message, Account? account) : base(status, message)
        {
            Account = account;
        }
    }
}