using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketPlace.Data.Entities.models;
using MarketPlace.Domain.Factories;
using MarketPlace.Domain.Repositories;
using MarketPlace.Presentation.Abstractions;
using MarketPlace.Presentation.Actions.MainMenu;

namespace MarketPlace.Presentation.Factories
{
    public class ProductFactory
    {
        public static ProductAction Create(Buyer buyer)
        {
            var actions = new List<IAction>()
            {
                new ListAllProductsAction(RepositoryFactory.Create<ProductRepository>(), RepositoryFactory.Create<BuyerRepository>())
            };

            var menuAction = new ProductAction(actions);
            return menuAction;
        }
    }
}
