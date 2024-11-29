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
    public class BuyProductAction:IAction
    {
        private readonly ProductRepository _productRepository;
        private readonly BuyerRepository _buyerRepository;
        private readonly TransactionRepository _transactionRepository;
        private readonly PromotionalCodeRepository _promotionalCodeRepository;
        private readonly Buyer _buyer;

        public string Name { get; set; } = "Buy product";
        public int MenuIndex { get; set; }

        public BuyProductAction(ProductRepository productRepository, BuyerRepository buyerRepository, Buyer buyer, TransactionRepository transactionRepository, PromotionalCodeRepository promotionalCodeRepository)
        {
            _productRepository = productRepository;
            _transactionRepository = transactionRepository;
            _buyerRepository = buyerRepository;
            _promotionalCodeRepository = promotionalCodeRepository;
            _buyer = buyer;
        }

        public void Open()
        {
            Reader.TryReadNumber("Unesite id proizvoda kojeg zelite kupit: ", out int id);
            var toBuy = _productRepository.GetProductById(id);
            while (toBuy is null) 
            {
                Console.WriteLine("Id kojeg ste unili ne postoji, probajte opet: ");
                Reader.TryReadNumber("Unesite id proizvoda kojeg zelite kupit: ", out id);
                toBuy = _productRepository.GetProductById(id);
            }

            if (!Reader.Confirmation("Jeli zelite upotrijebiti promocijski kod?"))
            {
                var status = _transactionRepository.NewTransaction(_buyer, toBuy);
                if (!status)
                {
                    Console.WriteLine("Proizvod je ili prodan ili nemate dovoljna sredstva, probajte neki drugi proizvod....");
                }
                else
                    Console.WriteLine($"Uspjesno kupljen proizvod {toBuy.Name}");

                Console.ReadKey();
                return;            }

            Reader.TryReadNumber("Unesite id koda", out var codeId);
            var code = _promotionalCodeRepository.GetCodeById(codeId);
            while (code is null)
            {
                Reader.TryReadNumber("Unesite id koda", out codeId);
                code = _promotionalCodeRepository.GetCodeById(codeId);
            }

            if (!_transactionRepository.NewTransaction(_buyer, toBuy, code))
            {
                Console.WriteLine("Nesto nije uredu, probajte drugi kod ili drugi proizvod. Provjerite stanje racuna.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Uspjesno kupljen proizvod {toBuy.Name}\nUstedili ste {code.Amount}\nStanje vaseg racuna: {_buyer.Balance}");
            Console.ReadKey();
        }
    }
}
