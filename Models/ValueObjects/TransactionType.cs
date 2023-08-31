using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleBank.Models.ValueObjects
{
    public enum TransactionType
    {
        Credit = 0,   
        Debit = 1,
    }
}