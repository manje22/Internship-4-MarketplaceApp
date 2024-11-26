using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Data.Entities.Models
{
    
    public class User
    {
        public User(string name, string email) { 
            Name = name; Email = email;
            Id = Guid.NewGuid();
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid Id { get; set; }
    }
}
