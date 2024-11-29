using MarketPlace.Data.Entities.Enums;
using MarketPlace.Data.Entities.models;
using MarketPlace.Domain.Repositories;
using MarketPlace.Presentation.Abstractions;
using MarketPlace.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Presentation.Actions.MerchantMainMenu
{
    public class GetSoldProductsByCategory:IAction 
    {
        private readonly ProductRepository _productRepository;
        private readonly MerchantRepository _merchantRepository;
        private readonly Merchant _merchant;

        public string Name { get; set; } = "View sold products by category";
        public int MenuIndex { get; set; }

        public GetSoldProductsByCategory(MerchantRepository merchantRepository, Merchant merchant, ProductRepository productRepository)
        {
            _merchantRepository = merchantRepository;
            _merchant = merchant;
            _productRepository = productRepository;
        }

        public void Open()
        {
            Console.WriteLine("Viewing sold products by category: ");

            foreach (ProductCategories category in Enum.GetValues(typeof(ProductCategories)))
            {
                Console.WriteLine($"{category}: ");
                Writer.Write(_merchantRepository.GetSoldProductsByCategory(_merchant, category));
            }
            //Writer.Write(_productRepository.GetProducts(_merchant).ToList());

            Console.ReadKey();
        }
    }
}
