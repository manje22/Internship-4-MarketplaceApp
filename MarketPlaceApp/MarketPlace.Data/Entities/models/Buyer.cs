using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Data.Entities.models
{
    public class Buyer : User
    {
        public double Balance { get; set; }
        public List<Product> FavoriteProducts { get; set; }
        public List<Product> PurchaseHistory { get; set; }
        public Buyer(double balance, List<Product> favoriteProducts, List<Product> purchaseHistory, string name,string email):base(name, email)
        {
            Balance = balance;
            FavoriteProducts = favoriteProducts;
            PurchaseHistory = purchaseHistory;
        }

        public Buyer(string name, string email, double balance) : base(name, email)
        {
            Balance = balance;
            FavoriteProducts = new List<Product>();
            PurchaseHistory = new List<Product>();
        }
    }
}
