using MarketPlace.Data.Entities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Repositories
{
    public class PromotionalCodeRepository : BaseRepository
    {
        protected readonly Data.Context Context;
        public PromotionalCodeRepository(Data.Context context) : base(context)
        {
            Context = context;
        }

        public ICollection<PromotionalCode> GetPromotionalCodes()
        {
            return Context.Promotions;
        }

        public ICollection<PromotionalCode> GetValidPromotionalCodes()
        {
            var codes = GetPromotionalCodes();
            return codes.Where(c => c.ExperationDate > DateTime.UtcNow).ToList();
        }

        public PromotionalCode GetCodeById(int id)
        {
            return Context.Promotions.FirstOrDefault(p => p.Id == id);
        }

    }
}
