using MarketPlace.Data.Entities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MarketPlace.Presentation.Helpers
{
    public class Writer
    {
        public static void Write(Buyer buyer)
        {
            Console.WriteLine($"{buyer.Name}: {buyer.Email}");
        }

        public static void Write(Transaction transaction)
        {
            Console.WriteLine($"{transaction.Buyer.Name}: {transaction.Merchant.Name}: {transaction.Product.Name}: {transaction.TimeOfPurchase} : {transaction.Product.Price}");
        }

        public static void Write(ICollection<Transaction> transactions)
        {
            foreach (var item in transactions)
            {
                Write($"{item.Product.Name} {item.TimeOfPurchase} {item.Product.Price}");
            }

            Console.ReadKey();
        }

        public static void WriteBuyers(ICollection<Buyer> buyers)
        {
            foreach (var buyer in buyers)
                Write(buyer);
        }

        public static void Write(Product product)
        {
            Console.WriteLine($"{product.Id}: {product.Name} : {product.Description} : {product.Price} - is sold:{product.IsSold} - kategorija : {product.Category}");
        }

        public static void Write(ICollection<Product> products)
        {
            foreach (var product in products)
            {
                Write(product);
            }

            Console.ReadKey();
        }

        public static void Write(string output)
        {
            Console.WriteLine(output);
        }
        public static void Error(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(1000);
            Console.Clear();
        }

        public static void HowShouldYourEmailLook(int number, string where)
        {
            Error($"Your email shoul contain at least {number} letter {where}.");
        }
    }
}
