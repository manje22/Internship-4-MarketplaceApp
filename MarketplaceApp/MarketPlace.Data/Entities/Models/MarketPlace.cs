using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Data.Entities.Models
{
    internal class MarketPlace
    {
        public List<User> Users { get; set; }
        public List<Product> Products { get; set; }
        public List<Transaction> Transactions { get; set; }
        public List<PromotionalCode> PromotionalCodes { get; set; }
    }
}
