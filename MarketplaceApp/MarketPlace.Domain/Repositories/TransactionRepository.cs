using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketPlace.Data.Entities.Models;
using MarketPlace.Domain.Enums;

namespace MarketPlace.Domain.Repositories
{
    internal class TransactionRepository
    {
        protected readonly Data.Context Context;
        public TransactionRepository(Data.Context context)
        {
            Context = context;
        }

        public StatusValues NewTransaction(Merchant merchant, Buyer buyer, Product product) {
            if (product.IsSold)
                return StatusValues.NotAvailable;
            if (buyer.Balance < product.Price)
                return StatusValues.NotEnoughFunds;

            var newTrasaction = new Transaction(buyer, merchant, product, DateTime.UtcNow);

            product.IsSold = true;
            buyer.Balance -= (double)product.Price;
            merchant.Income += (double)product.Price;

            Context.Transactions.Add(newTrasaction);
            buyer.PurchaseHistory.Add(product);

            return StatusValues.Success;
        }
    }
}
