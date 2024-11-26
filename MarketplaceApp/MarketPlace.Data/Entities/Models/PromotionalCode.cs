using MarketPlace.Data.Entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Data.Entities.Models
{
    internal class PromotionalCode
    {
        public Guid Id { get; set; }
        public ProductCategories Category { get; set; }
        public DateTime ExperationDate { get; set; }
        public PromotionalCode(ProductCategories category, DateTime experationDate) {
            Id = new Guid();
            Category = category;
            ExperationDate = experationDate;
        }    
    }
}
