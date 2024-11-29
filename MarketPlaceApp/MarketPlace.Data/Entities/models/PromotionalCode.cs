using MarketPlace.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Data.Entities.models
{
    public class PromotionalCode
    {
        public int Id { get; set; }
        public ProductCategories Category { get; set; }
        public DateTime ExperationDate { get; set; }
        public double Amount { get; set; }
        public PromotionalCode(ProductCategories category, DateTime experationDate, int id, double amount)
        {
            Id = id;
            Category = category;
            ExperationDate = experationDate;
            Amount = amount;
        }
    }
}
