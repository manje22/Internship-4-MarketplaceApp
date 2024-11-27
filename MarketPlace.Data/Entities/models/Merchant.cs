using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Data.Entities.models
{
    public class Merchant:User
    {
        public double Income { get; set; }
        public List<Product> Inventory { get; set; }
        public Merchant(string name, string email) : base(name, email)
        {
            Income = 0.0;
            Inventory = new List<Product>();
        }
    }
}
