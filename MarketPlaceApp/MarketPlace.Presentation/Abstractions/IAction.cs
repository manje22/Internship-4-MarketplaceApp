using MarketPlace.Data.Entities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Presentation.Abstractions
{
    public interface IAction
    {
        string Name { get; }
        int MenuIndex { get; set; }
        void Open();
    }
}
