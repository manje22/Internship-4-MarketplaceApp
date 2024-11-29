using MarketPlace.Domain.Repositories;
using MarketPlace.Presentation.Abstractions;
using MarketPlace.Presentation.Helpers;
using MarketPlace.Data.Entities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Presentation.Actions.MainMenu
{
    public class AddProductToFavorites : IAction
    {
        private readonly ProductRepository _productRepository;
        private readonly BuyerRepository _buyerRepository;
        private readonly Buyer _buyer;

        public string Name { get; set; } = "Add product to favorites";
        public int MenuIndex { get; set; }

        public AddProductToFavorites(ProductRepository productRepository, BuyerRepository buyerRepository, Buyer buyer)
        {
            _productRepository = productRepository;
            _buyerRepository = buyerRepository;
            _buyer = buyer;
        }

        public void Open()
        {
            Console.WriteLine("All available products");
            Writer.Write(_productRepository.GetProducts());

            Reader.TryReadNumber("\nUnesite id proizvoda kojeg zelite dodati u favorite", out int id);

            var productFav = _productRepository.GetProductById(id);
            while(productFav is null) 
            {
                Console.WriteLine("Uneseni id nije dostupan, probajte opet...");

                Reader.TryReadNumber("\nUnesite id proizvoda kojeg zelite dodati u favorite", out id);
                productFav = _productRepository.GetProductById(id);
            }

            var success = _buyerRepository.AddToFavorites(_buyer, productFav);

            if (success)
            {
                Console.WriteLine("Dodano u favorite\nVasi favoriti: ");
                Writer.Write(_buyerRepository.GetFavoriteProducts(_buyer));
            }
            else
            {
                Console.WriteLine("Proizvod je vec dodan u favorite, pritisnite bilo koju tipku za povratak");
                Console.ReadKey();
            }


        }
    }
}
