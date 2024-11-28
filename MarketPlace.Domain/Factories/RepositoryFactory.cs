using MarketPlace.Data;
using MarketPlace.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Factories
{
    public class RepositoryFactory
    {
        public static TRepository Create<TRepository>()
            where TRepository : BaseRepository
        {
            var context = ContextFactory.GetContext();
            var repositoryInstance = Activator.CreateInstance(typeof(TRepository), context) as TRepository;

            if (repositoryInstance ==null)
            {
                throw new InvalidOperationException($"Could not create instance of type {typeof(TRepository).Name}");
            }

            return repositoryInstance;
        }
    }
}
