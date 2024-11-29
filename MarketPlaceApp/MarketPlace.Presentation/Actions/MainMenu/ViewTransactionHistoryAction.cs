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
    public class ViewTransactionHistoryAction:IAction
    {
        private readonly TransactionRepository _transactionRepository;
        private readonly Buyer _buyer;

        public string Name { get; set; } = "View transaction history";
        public int MenuIndex { get; set; }

        public ViewTransactionHistoryAction(TransactionRepository transactionRepository, BuyerRepository buyerRepository, Buyer buyer)
        {
            _transactionRepository = transactionRepository;
            _buyer = buyer;
        }

        public void Open()
        {
            Console.WriteLine("Bought items");
            Writer.Write(_transactionRepository.GetTransactions().Where(t => t.Buyer == _buyer).ToList());
        }
    }
}
