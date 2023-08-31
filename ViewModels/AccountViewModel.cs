using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleBank.Models;

namespace SimpleBank.ViewModels
{
    public class AccountViewModel : BaseResponse
    {
        public Account? Account { get; set; }
        public AccountViewModel(int status, string message, Account? account) : base(status, message)
        {
            Account = account;
        }
    }
}