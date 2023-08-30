using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleBank.Models;

namespace SimpleBank.Usercases.GetAccountById
{
    public interface IGetAccountById
    {
        Task<Account?> GetAccount(int id);
    }
}