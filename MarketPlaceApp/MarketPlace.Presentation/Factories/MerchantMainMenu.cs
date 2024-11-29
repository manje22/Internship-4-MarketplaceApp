using MarketPlace.Data.Entities.models;
using MarketPlace.Domain.Factories;
using MarketPlace.Domain.Repositories;
using MarketPlace.Presentation.Abstractions;
using MarketPlace.Presentation.Actions.MainMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketPlace.Presentation.Actions.MainMenu;
using MarketPlace.Domain.Factories;
using MarketPlace.Domain.Repositories;
using MarketPlace.Presentation.Extentions;
using MarketPlace.Presentation.Actions.MerchantMainMenu;
using MarketPlace.Presentation.Actions;

namespace MarketPlace.Presentation.Factories
{
    public class MerchantMainMenu
    {
        public static IList<IAction> CreateActions(Merchant merchant)
        {
            Merchant _merchant = merchant;
            var actions = new List<IAction>()
            {
                new ViewInventoryAction(RepositoryFactory.Create<MerchantRepository>(), _merchant, RepositoryFactory.Create<ProductRepository>()),
                new AddProductToInventoryAction(RepositoryFactory.Create<ProductRepository>(), RepositoryFactory.Create<MerchantRepository>(), _merchant),
                new GetIncomeAction(RepositoryFactory.Create<MerchantRepository>(), _merchant),
                new GetSoldProductsByCategory(RepositoryFactory.Create<MerchantRepository>(), _merchant, RepositoryFactory.Create < ProductRepository >()),
                new ViewIncomeFilteredByTime(RepositoryFactory.Create<MerchantRepository>(), merchant, RepositoryFactory.Create<TransactionRepository>()),
                new ExitMenuAction(),
            };

            actions.SetActionIndexes();


            return actions;
        }
    }
}
