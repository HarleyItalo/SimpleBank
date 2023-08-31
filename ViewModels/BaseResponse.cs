using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.ViewModels
{
    public class BaseResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public BaseResponse(int status,string message)
        {
            Status = status;
            Message = message;
        }
    }
}