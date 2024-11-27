using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Repositories
{
    public class PromotionalCodeRepository
    {
        protected readonly Data.Context Context;
        public PromotionalCodeRepository(Data.Context context)
        {
            Context = context;
        }
    }
}
