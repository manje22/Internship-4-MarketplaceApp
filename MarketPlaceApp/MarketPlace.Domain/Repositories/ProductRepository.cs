using MarketPlace.Data.Entities.Enums;
using MarketPlace.Data.Entities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Repositories
{
    public class ProductRepository : BaseRepository
    {
        protected readonly Data.Context Context;
        public ProductRepository(Data.Context context) : base(context)
        {
            Context = context;
        }

        public void NewProduct(string name, string description, double price, Merchant merchant, ProductCategories category)
        {
            int id = Context.Products.Count +1;
            var product = new Product(name, description, price, merchant, category, id);
            Context.Products.Add(product);
            merchant.Inventory.Add(product);
        }

        public ICollection<Product> GetProducts()
        {
            return Context.Products;
        }

        public ICollection<Product> GetProductsForSale()
        {
            return GetProducts().Where(p => !p.IsSold).ToList();
        }

        public ICollection<Product> GetProducts(Merchant merchant)
        {
            var products = Context.Products.Where(p => p.Merchant.Name == merchant.Name).ToList();
            return products;
        }

        public Product? GetProductById(int id)
        {
            return Context.Products.FirstOrDefault(p => p.Id == id);
        }

        public ProductCategories ChooseCategory(string input)
        {
            switch(input)
            {
                case "1":
                    return ProductCategories.Food;
                case "2":
                    return ProductCategories.Clothing;
                case "3":
                    return ProductCategories.Furniture;
                 
            }
            //if value is 4 then electronics is returned
            return ProductCategories.Electronics;
        }
    }
}
