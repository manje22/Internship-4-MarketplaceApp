using MarketPlace.Data.Entities.models;
using MarketPlace.Data;
using MarketPlace.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Repositories
{
    public class TransactionRepository : BaseRepository
    {
        public TransactionRepository(Context context) : base(context)
        { }

        public bool NewTransaction(Buyer buyer, Product product)
        {
            if (product.IsSold || buyer.Balance < product.Price)
                return false;


            var newTrasaction = new Transaction(buyer, product, DateTime.UtcNow);

            context.Transactions.Add(newTrasaction);
            product.IsSold = true;
            buyer.Balance -= (double)product.Price;
            product.Merchant.Income += (double)product.Price*0.95;//marketplace takes 5%
            buyer.PurchaseHistory.Add(product);

            return true;
        }

        public bool NewTransaction(Buyer buyer, Product product, PromotionalCode promotionalCode)
        {
            if (product.IsSold || buyer.Balance < product.Price)
                return false;
            if (promotionalCode.ExperationDate <DateTime.Now)
                return false;
            if (promotionalCode.Category != product.Category)
                return false;

            var newTrasaction = new Transaction(buyer, product, DateTime.UtcNow);

            var discount = promotionalCode.Amount;
            var newPrice = product.Price * (1 - discount);

            product.IsSold = true;
            buyer.Balance -= (double)newPrice;
            product.Merchant.Income += (double)newPrice * 0.95;//marketplace takes 5%
            buyer.PurchaseHistory.Add(product);

            return true;
        }

        public ICollection<Transaction> GetTransactions() 
        {
            return context.Transactions;
        }

        public bool CheckIfPurchased(Buyer buyer, int id)  
        {
            return context.Transactions.Any(t => t.Buyer == buyer && t.Product.Id == id);
        }

        public ICollection<Transaction> GetTransactionsFilteredByMerchant(Merchant merchant, DateTime startDate, DateTime endDate)
        {
            return context.Transactions
                  .Where(t => t.Merchant == merchant
                           && t.TimeOfPurchase >= startDate
                           && t.TimeOfPurchase <= endDate)
                  .ToList();
        }

        public double CalculateIncome(Merchant merchant, DateTime startDate, DateTime endDate)
        {
            var products = GetTransactionsFilteredByMerchant (merchant, startDate, endDate);
            var income = SumOfIncome(products);
            return income;
        }
            

        public double SumOfIncome(ICollection<Transaction> transactions)
        {
            double income = 0;
            foreach (var item in transactions)
            {
                decimal price = (decimal)item.Product.Price;
                income += (double)Math.Round(price, 2);
            }

            return income;
        }
    }
}
