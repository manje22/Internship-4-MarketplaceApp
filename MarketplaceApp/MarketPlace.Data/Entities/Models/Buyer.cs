using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Data.Entities.Models
{
    public class Buyer : User
    {
        public double Balance { get; set; }
        public List<Product> FavoriteProducts { get; set; }
        public List<Product> PurchaseHistory { get; set; }
        public Buyer(string name, string email): base(name, email)
        {
            Balance = 100;
            FavoriteProducts = new List<Product>();
            PurchaseHistory = new List<Product>();
        }

    }
}
