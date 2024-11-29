using MarketPlace.Data.Entities.Enums;
using MarketPlace.Data.Entities.models;
using MarketPlace.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Repositories
{
    public class MerchantRepository : BaseRepository
    {
        public MerchantRepository(Context context) : base(context) { }

        public void AddMerchant(string name, string email)
        {
            var merchant = new Merchant(name, email);

            context.Merchants.Add(merchant);

        }


        public ICollection<Product> GetSoldProducts(Merchant merchant)
        {
            var products = context.Products.Where(p => p.Merchant == merchant && p.IsSold).ToList();
            return products;
        }

        public ICollection<Product> GetSoldProductsByCategory(Merchant merchant, ProductCategories category)
        {
            var products = GetSoldProducts(merchant).Where(p => p.Category == category).ToList();
            return products;
        }

        public double GetIncome(Merchant merchant)
        {
            var products = GetSoldProducts(merchant);
            double income = 0;
            foreach (var item in products)
            {
                decimal price = (decimal)item.Price;
                income += (double)Math.Round(price, 2);
            }

            return income;
        }

        public List<Product> GetProductsByCategory(ProductCategories category, Merchant merchant)
        {
            if (merchant is null)
            {
                return null;
            }

            var products = merchant.Inventory.Where(p => p.Category == category);
            return (List<Product>)products;
        }

        public Merchant? GetByEmail(string email)
        {
            foreach (var merchant in context.Merchants)
            {
                if (merchant.Email == email)
                    return merchant;
            }

            return null;
        }
    }
}
