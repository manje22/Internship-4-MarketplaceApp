using MarketPlace.Data.Entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Data.Entities.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public bool IsSold { get; set; }
        public Merchant Merchant { get; set; }
        public ProductCategories Category { get; set; }
        public double Rating { get; set; }

        public Product(string name, string description, double price, Merchant merchant, ProductCategories category)
        {
            Name = name;
            Description = description;
            Price = price;
            Merchant = merchant;
            Category = category;
            Rating = double.NaN;
            IsSold = false;
        }
    }
}
