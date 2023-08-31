using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.ViewModels
{
    public class BaseResponseViewModel
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public BaseResponseViewModel(int status,string message)
        {
            Status = status;
            Message = message;
        }
    }
}