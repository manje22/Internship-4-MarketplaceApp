using MarketPlace.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarketPlace.Data.Entities.models
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

        public Product(string name, string description, double price, Merchant merchant, ProductCategories category, int id, bool isSold)
        {
            Name = name;
            Description = description;
            Price = price;
            Merchant = merchant;
            Category = category;
            Rating = double.NaN;
            IsSold = isSold;
            Id = id;
        }
        public Product(string name, string description, double price, Merchant merchant, ProductCategories category, int id)
        {
            Name = name;
            Description = description;
            Price = price;
            Merchant = merchant;
            Category = category;
            Rating = double.NaN;
            IsSold = false;
            Id = id;
        }
    }
}
