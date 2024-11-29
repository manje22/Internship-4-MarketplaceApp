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
    public class ViewFavoritesAction:IAction
    {
        private readonly ProductRepository _productRepository;
        private readonly BuyerRepository _buyerRepository;
        private readonly Buyer _buyer;

        public string Name { get; set; } = "View favorites";
        public int MenuIndex { get; set; }

        public ViewFavoritesAction(ProductRepository productRepository, BuyerRepository buyerRepository, Buyer buyer)
        {
            _productRepository = productRepository;
            _buyerRepository = buyerRepository;
            _buyer = buyer;
        }

        public void Open()
        {
            Writer.Write(_buyerRepository.GetFavoriteProducts(_buyer));
        }
    }
}
