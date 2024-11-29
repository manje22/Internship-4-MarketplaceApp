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
    public class GetIncomeAction:IAction
    {
        //private readonly ProductRepository _productRepository;
        private readonly MerchantRepository _merchantRepository;
        private readonly Merchant _merchant;

        public string Name { get; set; } = "View income";
        public int MenuIndex { get; set; }

        public GetIncomeAction(MerchantRepository merchantRepository, Merchant merchant)
        {
            _merchantRepository = merchantRepository;
            _merchant = merchant;
        }

        public void Open()
        {
            Console.WriteLine("Viewing income: ");

            Console.WriteLine($"{_merchant.Name} income: {_merchantRepository.GetIncome(_merchant)}");

            Console.ReadKey();
        }
    }
}
