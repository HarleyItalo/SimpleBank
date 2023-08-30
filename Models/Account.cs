using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SimpleBank.Models
{
    [PrimaryKey(nameof(AccoutId))]
    public class Account
    {
        public int AccoutId;
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }

        public Account(string name,string lastName)
        {   
            Name = name;
            LastName = lastName;
        }
    }
}