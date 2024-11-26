using MarketPlace.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Data
{
    public class Context
    {
        public List<Buyer> Buyers = Seed.Buyers;
        public List<Merchant> Merchants = Seed.Merchants;
        public List<Transaction> Transactions = Seed.Transactions;
        public List<Product> Products = Seed.Products;

    }
}
