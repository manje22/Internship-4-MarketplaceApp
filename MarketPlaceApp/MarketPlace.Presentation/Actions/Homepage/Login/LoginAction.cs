using MarketPlace.Data.Entities.models;
using MarketPlace.Domain.Repositories;
using MarketPlace.Presentation.Abstractions;
using MarketPlace.Presentation.Helpers;
using MarketPlace.Presentation.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Presentation.Actions.Homepage.Login
{
    internal class LoginAction : IAction
    {
        private readonly BuyerRepository _buyerRepository;
        private readonly MerchantRepository _merchantRepository;
        public string Name { get; set; } = "Log in";
        public User User { get; set; }
        public int MenuIndex { get; set; }

        public LoginAction(BuyerRepository buyerRepository, MerchantRepository merchantRepository)
        {
            _buyerRepository = buyerRepository;
            _merchantRepository = merchantRepository;
        }
        public void Open()
        {
            var buyerOrMerchant = Reader.BuyerOrMerchant();
            User user = null;
            if (buyerOrMerchant)
            {
                user = FindUser(true);
            }
            else
                user = FindUser();

            while (user == null)
            {
                Thread.Sleep(300);
                bool cont = Reader.DoYouWantToContinue();
                if (cont)
                    switch (buyerOrMerchant)
                    {
                        case (true):
                            user = FindUser(true);
                            break;
                        case (false):
                            user = FindUser();
                            break;
                    }
                    
                else
                    ActionExtensions.PrintActions();
            }
            //napravi da su useri pa onda is buyer is merchant
            if (user is Merchant)
            {
                ActionExtensions.PrintMerchantActions(user as Merchant);
                return;
            }
            ActionExtensions.PrintBuyerActions(user as Buyer);
            return;
            
        }

        public Buyer? FindUser()
        {
            Console.Clear();
            Reader.TryReadLine("Enter your email", out string email);

            Buyer? buyer = _buyerRepository.GetByEmail(email);
            return buyer;
        }

        public Merchant? FindUser(bool t) 
        {
            Console.Clear();
            Reader.TryReadLine("Enter your email", out string email);

            Merchant? merchant = _merchantRepository.GetByEmail(email);
            return merchant;
        }
    }
}
