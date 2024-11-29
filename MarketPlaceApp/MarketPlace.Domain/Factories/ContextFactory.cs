using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketPlace.Data;

namespace MarketPlace.Domain.Factories
{
    public static class ContextFactory
    {
        private static Context? _context;
        public static Context GetContext()
        {
            if (_context == null)
            {
                _context = new Context();
            }
            
            return _context;
        }
    }
}
