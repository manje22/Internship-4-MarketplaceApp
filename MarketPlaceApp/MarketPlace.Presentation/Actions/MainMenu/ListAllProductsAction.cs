using MarketPlace.Data.Entities.models;
using MarketPlace.Domain.Repositories;
using MarketPlace.Presentation.Abstractions;
using MarketPlace.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Presentation.Actions.MainMenu
{
    public class ListAllProductsAction : IAction
    {
        private readonly ProductRepository _productRepository;

        public string Name { get; set; } = "List all products for sale";
        public int MenuIndex { get; set; }

        public ListAllProductsAction(ProductRepository productRepository, BuyerRepository buyerRepository)
        {
            _productRepository = productRepository;

        }

        public void Open()
        {
            Console.WriteLine("All avaiable products");
            Writer.Write(_productRepository.GetProductsForSale());
        }
    }
}
