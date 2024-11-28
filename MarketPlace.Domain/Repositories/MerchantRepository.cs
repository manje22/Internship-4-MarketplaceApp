using MarketPlace.Data.Entities.Enums;
using MarketPlace.Data.Entities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Repositories
{
    public class MerchantRepository:BaseRepository
    {
        protected readonly Data.Context Context;
        public MerchantRepository(Data.Context context):base(context) { }
        
        public void AddMerchant(string name, string email)
        {
            var merchant = new Merchant(name, email);

            Context.Merchants.Add(merchant);

        }

        public List<Product> GetAllProducts(string email)
        {
            var merchant = GetByEmail(email);
            if (merchant is null)
            {
                return null;
            }

            var products = merchant.Inventory;
            return products;
        }

        public double GetIncome(string email)
        {
            var merchant = GetByEmail(email);
            if (merchant is null)
            {
                return double.NaN;
            }

            var income = merchant.Income;
            return income;
        }

        public List<Product> GetProductsByCategory(ProductCategories category, string email)
        {
            var merchant = GetByEmail(email);
            if (merchant is null)
            {
                return null;
            }

            var products = merchant.Inventory.Where(p => p.Category == category);
            return (List<Product>)products;
        }

        public Merchant GetByEmail(string email) => Context.Merchants.FirstOrDefault(u => u.Email == email);
    }
}
