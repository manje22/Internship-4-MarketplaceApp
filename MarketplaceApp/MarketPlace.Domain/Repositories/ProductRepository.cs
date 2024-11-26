using MarketPlace.Data.Entities.enums;
using MarketPlace.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Repositories
{
    internal class ProductRepository
    {
        protected readonly Data.Context Context;
        public ProductRepository(Data.Context context)
        {
            Context = context;
        }

        public void NewProduct(string name, string description, double price, Merchant merchant, ProductCategories category) {
            var product = new Product(name, description, price, merchant, category);
            Context.Products.Add(product);
            merchant.Inventory.Add(product);
        }
    }
}
