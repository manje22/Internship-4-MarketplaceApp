using MarketPlace.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Presentation.Actions.MainMenu
{
    public class ProductAction : BaseMenuAction
    {
        public ProductAction(IList<IAction> actions) : base (actions) 
        {
            Name = "Products";
        }

        public override void Open()
        {
            Console.WriteLine("Product options");
            base.Open();
        }
    }
}
