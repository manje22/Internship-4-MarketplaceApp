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
        public PromotionalCode(ProductCategories category, DateTime experationDate)
        {
            Category = category;
            ExperationDate = experationDate;
        }
    }
}
