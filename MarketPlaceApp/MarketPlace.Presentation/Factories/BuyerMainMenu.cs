using MarketPlace.Presentation.Abstractions;
using MarketPlace.Data.Entities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketPlace.Presentation.Actions.MainMenu;
using MarketPlace.Domain.Factories;
using MarketPlace.Domain.Repositories;
using MarketPlace.Presentation.Extentions;
using MarketPlace.Presentation.Actions;

namespace MarketPlace.Presentation.Factories
{
    public class BuyerMainMenu
    {
        public static IList<IAction> CreateActions(Buyer buyer)
        {
            Buyer _buyer = buyer;
            var actions = new List<IAction>()
            {
                new ListAllProductsAction(RepositoryFactory.Create<ProductRepository>(), RepositoryFactory.Create<BuyerRepository>()),
                new AddProductToFavorites(RepositoryFactory.Create<ProductRepository>(), RepositoryFactory.Create<BuyerRepository>(), _buyer),
                new ViewFavoritesAction(RepositoryFactory.Create<ProductRepository>(), RepositoryFactory.Create<BuyerRepository>(), _buyer),
                new BuyProductAction(RepositoryFactory.Create<ProductRepository>(), RepositoryFactory.Create<BuyerRepository>(), _buyer, RepositoryFactory.Create<TransactionRepository>(), RepositoryFactory.Create<PromotionalCodeRepository>()),
                new ViewTransactionHistoryAction(RepositoryFactory.Create<TransactionRepository>(), RepositoryFactory.Create<BuyerRepository>(), buyer),
                new ReturnProductAction(RepositoryFactory.Create<ProductRepository>(), RepositoryFactory.Create<BuyerRepository>(),_buyer, RepositoryFactory.Create<TransactionRepository>()),
                new ExitMenuAction(),
            };

            actions.SetActionIndexes();


            return actions;
        }
    }
}
