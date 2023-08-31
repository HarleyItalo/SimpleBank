using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleBank.Models;

namespace SimpleBank.Usercases.TransactionsByUser
{
    public interface ITransactionsByUser
    {
         public  Task<List<Transaction>?> Get(int accountId);
    }
}