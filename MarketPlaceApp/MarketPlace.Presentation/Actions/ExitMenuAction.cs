using MarketPlace.Data.Entities.models;
using MarketPlace.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Presentation.Actions
{
    public class ExitMenuAction : IAction
    {
        public Buyer buyer { get; set; }
        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Exit";

        public ExitMenuAction()
        {
        }

        public void Open()
        {
        }
    }
}
