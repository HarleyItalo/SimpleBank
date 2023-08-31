using Microsoft.EntityFrameworkCore;
using SimpleBank.Models.ValueObjects;

namespace SimpleBank.Models
{
    [PrimaryKey(nameof(TransactionId))]
    public class Transaction
    {
        public int TransactionId { get; set; }
        public TransactionType TransactionType { get; set; }
        public double Value { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int AccountId { get; set; }
        public Account? Account { get; set; }
    }
}