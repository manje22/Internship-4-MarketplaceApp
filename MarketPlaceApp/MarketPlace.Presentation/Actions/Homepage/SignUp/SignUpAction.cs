using MarketPlace.Data.Entities.models;
using MarketPlace.Domain.Repositories;
using MarketPlace.Presentation.Abstractions;
using MarketPlace.Presentation.Extentions;
using MarketPlace.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Presentation.Actions.Homepage.SignUp
{
    public class SingInAction : IAction
    {
        public string Name { get; set; } = "Sign up";
        private readonly BuyerRepository _buyerRepository;
        private readonly MerchantRepository _merchantRepository;

        public int MenuIndex { get; set; }
        public SingInAction(BuyerRepository buyerRepository, MerchantRepository merchantRepository)
        {
            _buyerRepository = buyerRepository;
            _merchantRepository = merchantRepository;

        }
        public void Open()
        {
            var email = ActionExtensions.CorrectEmailChoice();
            Buyer? buyer = _buyerRepository.GetByEmail(email);
            Merchant? merchant = _merchantRepository.GetByEmail(email);
            while(buyer != null || merchant != null)
            {
                Writer.Error("Vec postoji korisnik istog email-a.");
                email = ActionExtensions.CorrectEmailChoice();
                buyer = _buyerRepository.GetByEmail(email);
                merchant = _merchantRepository.GetByEmail(email);
                //ActionExtensions.PrintActions();
            }

            var name = Reader.ReadInput("Unesite ime: ");

            var buyerOrMerchant = Reader.BuyerOrMerchant();

            if (buyerOrMerchant)
            {
                _merchantRepository.AddMerchant(name, email);
                Console.WriteLine($"Added new merchant {name}");
            }
            else
            {
                var balance = Reader.TryReadDouble("Unesite pocetni iznos racuna: ");
                _buyerRepository.Add(name, email, balance);
                Console.WriteLine($"Added new buyer {name}");
            }

            Console.ReadLine();

        }
    }
}
