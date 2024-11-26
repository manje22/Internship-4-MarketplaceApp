using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using MarketPlace.Data.Entities.Models;
using MarketPlace.Data.Entities;
using MarketPlace.Data;

namespace MarketPlace.Domain.Repositories
{
    public class BuyerRepository
    {
        protected readonly Data.Context Context;
        public BuyerRepository(Data.Context context) {
            Context = context;
        }

        public bool Add(Buyer buyer)
        {
            Context.Buyers.Add(buyer);
            return true;
        }

        public bool AddToFavorites(Buyer buyer, Product product) {
            buyer.FavoriteProducts.Add(product);
            return true;
        }

        public bool RemoveFromFavorites(Buyer buyer, Product product)
        {
            buyer.FavoriteProducts.Remove(product);
            return true;
        }

        public List<Product> GetFavoriteProducts(Buyer buyer) {
            return buyer.FavoriteProducts;
        }

        public List<Product> GetPurchasedProducts(Buyer buyer)
        {
            return buyer.PurchaseHistory;
        }

        public Buyer GetById(Guid id) => Context.Buyers.FirstOrDefault(u => u.Id == id);

        public  BuyProduct(User user, Product product)
        {
            
        }

    }
}
