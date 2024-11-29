using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Data.Entities.models
{
    public class Transaction
    {
        public Product Product { get; set; }
        public Buyer Buyer { get; set; }
        public Merchant Merchant { get; set; }
        public DateTime TimeOfPurchase { get; set; }
        

        public Transaction(Buyer buyer,Product product, DateTime timeOfPurchase)
        {
            this.Buyer = buyer;
            this.Merchant = product.Merchant;
            this.Product = product;
            this.TimeOfPurchase = timeOfPurchase;
            product.IsSold = true;
        }
    }
}
