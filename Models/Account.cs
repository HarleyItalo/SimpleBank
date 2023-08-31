using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace SimpleBank.Models
{
    [PrimaryKey(nameof(AccoutId))]
    public class Account
    {
        public int AccoutId;
        public string Name { get; set; }
        public string LastName { get; set; }

        [JsonIgnore]
        public List<Transaction>? Transactions { get; set; }

        public Account(string name,string lastName)
        {   
            Name = name;
            LastName = lastName;
        }
    }
}