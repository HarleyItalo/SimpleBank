using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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