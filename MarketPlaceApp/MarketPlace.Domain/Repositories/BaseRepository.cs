using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketPlace.Data;

namespace MarketPlace.Domain.Repositories
{
    public class BaseRepository
    {
        protected readonly Context context;

        protected BaseRepository(Context context)
        {
            this.context = context;
        }
    }
}
