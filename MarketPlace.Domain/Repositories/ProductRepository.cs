using MarketPlace.Data.Entities.Enums;
using MarketPlace.Data.Entities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Repositories
{
    public class ProductRepository:BaseRepository
    {
        protected readonly Data.Context Context;
        public ProductRepository(Data.Context context):base(context)
        {
            Context = context;
        }

        public void NewProduct(string name, string description, double price, Merchant merchant, ProductCategories category)
        {
            var product = new Product(name, description, price, merchant, category);
            Context.Products.Add(product);
            merchant.Inventory.Add(product);
        }
    }
}
