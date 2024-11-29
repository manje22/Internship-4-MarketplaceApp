using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketPlace.Domain.Repositories;
using MarketPlace.Data;

namespace MarketPlace.Domain.Factories
{
    public class RepositoryFactory
    {
        public static TRepository Create<TRepository>()
            where TRepository : BaseRepository
        {
            var context = new Context();
            var repositoryInstance = Activator.CreateInstance(typeof(TRepository), context) as TRepository;

            if (repositoryInstance == null)
            {
                throw new InvalidOperationException($"Could not create instance of type {typeof(TRepository).Name}");
            }

            return repositoryInstance;
        }
    }
}
