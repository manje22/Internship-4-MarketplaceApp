using MarketPlace.Data.Entities.Enums;
using MarketPlace.Data.Entities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarketPlace.Data
{
    public static class Seed
    {
        private static Buyer mariela = new Buyer("Mariela", "muvodic@pmfst.hr", 200);
        private static Buyer duje = new Buyer("Duje", "doreilly@pmfst.hr", 100);
        private static Buyer jay = new Buyer("Jay", "jayjepas@mail.com", 50);
        private static Merchant Miso = new Merchant("Miso", "miso@mail.com");
        private static Merchant Marjan = new Merchant("Marjan", "marjan@mail.com");
        private static Product mouse = new Product("mis", "rozi mis na kabel", 10.99, Miso,ProductCategories.Electronics,1, false);
        private static Product headphones = new Product("sluse", "crne sluse", 10.99, Marjan, ProductCategories.Electronics,2, false);
        private static Product shirt = new Product("shirt", "short sleeved shirt", 5.99, Miso, ProductCategories.Clothing, 3, true);
        private static Product bread = new Product("bread", "loaf of bread", 2.99, Miso, ProductCategories.Food, 4, true);
        private static Product couch = new Product("couch", "living room couch", 50.50, Miso, ProductCategories.Furniture, 5, false);
        private static Product pant = new Product("pants", "clothing pants", 7.30, Miso, ProductCategories.Clothing, 6, true);
        private static Transaction t1 = new Transaction(duje, pant, DateTime.Parse("2024-10-05 12:34"));
        private static Transaction t2 = new Transaction(jay, bread, DateTime.Parse("2024-11-25 13:40"));
        private static Transaction t3 = new Transaction(duje, shirt, DateTime.Parse("2024-10-27 17:20"));


        public static readonly List<Buyer> Buyers = new List<Buyer>()
        {
            mariela,
            duje,
            jay,

        };

        public static readonly List<Merchant> Merchants = new List<Merchant>()
        {
            Miso, Marjan,

        };

        public static readonly List<Product> Products = new List<Product>()
        {
            
            mouse, headphones, shirt, bread, couch, pant,

        };

        public static readonly List<Transaction> Transactions = new List<Transaction>()
        {
            t1, t2, t3

        };

        public static readonly List<PromotionalCode> Promotions = new List<PromotionalCode>()
        {
            new PromotionalCode(ProductCategories.Clothing, DateTime.Parse("2024-10-27"), 1, 0.50),
            new PromotionalCode(ProductCategories.Food, DateTime.Parse("2024-10-31"), 2, 0.25),
            new PromotionalCode(ProductCategories.Furniture, DateTime.Parse("2024-11-30"), 3, 0.30),
            new PromotionalCode(ProductCategories.Electronics, DateTime.Parse("2024-12-27"), 4, 0.40),
            new PromotionalCode(ProductCategories.Clothing, DateTime.Parse("2024-12-31"), 5, 0.25),
        };
    }
}
