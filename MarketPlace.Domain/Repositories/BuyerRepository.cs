using MarketPlace.Data.Entities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Repositories
{
    public class BuyerRepository
    {
        protected readonly Data.Context Context;
        public BuyerRepository(Data.Context context)
        {
            Context = context;
        }

        public bool Add(Buyer buyer)
        {
            Context.Buyers.Add(buyer);
            return true;
        }

        public bool AddToFavorites(Buyer buyer, Product product)
        {
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

        public Buyer GetByEmail(string email) => Context.Buyers.FirstOrDefault(u => u.Email == email);
    }
}
