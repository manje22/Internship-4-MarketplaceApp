using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketPlace.Data;
using MarketPlace.Data.Entities.models;

namespace MarketPlace.Domain.Repositories
{
    public class BuyerRepository : BaseRepository
    {

        public BuyerRepository(Context context) : base(context) { }

        public bool Add(string name, string email, double balance)
        {
            context.Buyers.Add(new Buyer(name, email, balance));
            return true;
        }

        public bool AddToFavorites(Buyer buyer, Product product)
        {
            if (buyer.FavoriteProducts.Contains(product))
            {
                return false;
            }
            buyer.FavoriteProducts.Add(product);
            return true;
        }

        public bool RemoveFromFavorites(Buyer buyer, Product product)
        {
            buyer.FavoriteProducts.Remove(product);
            return true;
        }

        public List<Product> GetFavoriteProducts(Buyer buyer)
        {
            return buyer.FavoriteProducts;
        }

        public List<Product> GetPurchasedProducts(Buyer buyer)
        {
            return buyer.PurchaseHistory;
        }

        public bool CheckIfPurchased(Buyer buyer, int id)   
        {
            var purchaseHistory = GetPurchasedProducts(buyer);
            return purchaseHistory.Any(p => p.Id == id);
        }

        public Buyer? GetByEmail(string email)
        {
            foreach (var buyer in context.Buyers)
            {
                if (buyer.Email == email)
                    return buyer;
            }

            return null;
        }

        public void ReturnProduct(Buyer buyer, Product product)
        {
            product.IsSold = false;
            buyer.Balance += Math.Round((double)product.Price * 0.8);
            product.Merchant.Income -= Math.Round((double)product.Price - 0.85 * (double)product.Price);
        }
    }
}
