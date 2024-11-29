using MarketPlace.Data.Entities.models;
using MarketPlace.Domain.Repositories;
using MarketPlace.Presentation.Abstractions;
using MarketPlace.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Presentation.Actions.MainMenu
{
    public class ReturnProductAction:IAction
    {
        private readonly ProductRepository _productRepository;
        private readonly BuyerRepository _buyerRepository;
        private readonly TransactionRepository _transactionRepository;
        private readonly Buyer _buyer;

        public string Name { get; set; } = "Return product";
        public int MenuIndex { get; set; }

        public ReturnProductAction(ProductRepository productRepository, BuyerRepository buyerRepository, Buyer buyer, TransactionRepository transactionRepository)
        {
            _productRepository = productRepository;
            _transactionRepository = transactionRepository;
            _buyerRepository = buyerRepository;
            _buyer = buyer;
        }

        public void Open()
        {
            Reader.TryReadNumber("Unesite id proizvoda kojeg zelite vratit: ", out int id);
            var toReturn = _productRepository.GetProductById(id);
            var isPurchased = _transactionRepository.CheckIfPurchased(_buyer, id);
            while(!isPurchased) 
            {
                Reader.TryReadNumber($"Niste kupili proizvod id-a {toReturn.Id}\nUnesite valjan id proizvoda: ", out id);
                toReturn = _productRepository.GetProductById(id);
                isPurchased = _buyerRepository.CheckIfPurchased(_buyer, id);
            }

            _buyerRepository.ReturnProduct(_buyer, toReturn);
            Console.WriteLine($"Uspjeno vracen {toReturn.Name}\nTrenutno stanje vaseg racuna: {_buyer.Balance}");
            Console.ReadKey();
        }
    }
}
