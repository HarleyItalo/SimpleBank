namespace SimpleBank.ViewModels
{
    public class BalanceViewModel : BaseResponseViewModel
    {
        public BalanceViewModel(int status, string message,double balance) : base(status, message)
        {
            Balance = balance;
        }

        public double Balance { get; set; }
    }
}