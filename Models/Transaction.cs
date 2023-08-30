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

        public DateTime CreatedAt { get; set; }
    }
}