using MarketPlace.Data.Entities.models;
using MarketPlace.Domain.Repositories;
using MarketPlace.Presentation.Abstractions;
using MarketPlace.Data.Entities.Enums;
using MarketPlace.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Presentation.Actions.MerchantMainMenu
{
    public class AddProductToInventoryAction : IAction
    {
        private readonly ProductRepository _productRepository;
        private readonly MerchantRepository _merchantRepository;
        private readonly Merchant _merchant;

        public string Name { get; set; } = "Add new product";
        public int MenuIndex { get; set; }

        public AddProductToInventoryAction(ProductRepository productRepository, MerchantRepository merchantRepository, Merchant merchant)
        {
            _productRepository = productRepository;
            _merchantRepository = merchantRepository;
            _merchant = merchant;
        }

        public void Open()
        {
            Console.WriteLine("Add new product");
            var name = Reader.ReadInput("Unesite naziv proizvoda: ");
            var description = Reader.ReadInput("Unesite opis proizvoda: ");
            var price = Reader.TryReadDouble("Unesite cijenu proizvoda: ");

            //int catNum = int.;
            //while (catNum !=  0  catNum>4)
            //{
                
            //}

            var catNum = Reader.TryReadNumberForCategory("Odabir kategorija\n1.) Hrana\n2.) Odjeca\n3.) Namjestaj\n4.) Elektronika");
            var category = _productRepository.ChooseCategory(catNum);
            _productRepository.NewProduct(name, description, price, _merchant, category);

            Console.WriteLine("Dodan novi proizvod");
            Console.ReadKey();
        }
    }
}
