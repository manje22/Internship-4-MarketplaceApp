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
    public class ViewInventoryAction: IAction
    {
        private readonly ProductRepository _productRepository;
        private readonly MerchantRepository _merchantRepository;
        private readonly Merchant _merchant;

        public string Name { get; set; } = "View inventory";
        public int MenuIndex { get; set; }

        public ViewInventoryAction(MerchantRepository merchantRepository, Merchant merchant, ProductRepository productRepository)
        {
            _merchantRepository = merchantRepository;
            _merchant = merchant;
            _productRepository = productRepository;
        }

        public void Open()
        {
            Console.WriteLine("Viewing all products in inventory: ");

            Writer.Write(_productRepository.GetProducts(_merchant).ToList());

            Console.ReadKey();
        }
    }
}
