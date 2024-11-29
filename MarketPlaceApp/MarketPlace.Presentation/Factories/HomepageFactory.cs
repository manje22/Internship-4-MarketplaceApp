using MarketPlace.Domain.Factories;
using MarketPlace.Domain.Repositories;
using MarketPlace.Presentation.Abstractions;
using MarketPlace.Presentation.Actions.Homepage.Login;
using MarketPlace.Presentation.Actions.Homepage.SignUp;
using MarketPlace.Presentation.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketPlace.Presentation.Extentions;

namespace MarketPlace.Presentation.Factories
{
    public class HomepageFactory
    {
        public static IList<IAction> CreateActions()
        {
            var actions = new List<IAction>
            {
            new LoginAction(RepositoryFactory.Create<BuyerRepository>(), RepositoryFactory.Create<MerchantRepository>()),
            new SingInAction(RepositoryFactory.Create<BuyerRepository>(), RepositoryFactory.Create<MerchantRepository>()),
            new ExitMenuAction(),
            };

            actions.SetActionIndexes();

            return actions;
        }
    }
}
