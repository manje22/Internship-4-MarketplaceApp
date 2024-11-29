using MarketPlace.Data.Entities.models;
using MarketPlace.Presentation.Abstractions;
using MarketPlace.Domain.Repositories;
using MarketPlace.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Presentation.Actions.MerchantMainMenu
{
    public class ViewIncomeFilteredByTime: IAction
    {
        private readonly MerchantRepository _merchantRepository;
        private readonly Merchant _merchant;
        private readonly TransactionRepository _transactionRepository;

        public string Name { get; set; } = "Prihod u odbaranom vremenskom intervalu";
        public int MenuIndex { get; set; }

        public ViewIncomeFilteredByTime(MerchantRepository merchantRepository, Merchant merchant, TransactionRepository transactionRepository)
        {
            _merchantRepository = merchantRepository;
            _merchant = merchant;
            _transactionRepository = transactionRepository;
        }

        public void Open()
        {
            var start = Reader.InputDate("Unesite pocetni datum: ");
            var end = Reader.InputDate("Unesite zavrsni datum: ");
            var transactions = _transactionRepository.GetTransactionsFilteredByMerchant(_merchant, start, end);
            if (transactions is not null)
            {
                Console.WriteLine("Sve transakcije u odabranom vremeu: ");
                Writer.Write(transactions);
                var income = _transactionRepository.SumOfIncome(transactions);
                //Console.WriteLine("Ukupan prihod\n\n");
                //var sum = Math.Round((decimal)transactions.Sum(t => t.Product.Price));
                //Console.WriteLine($"Prihod za odabrano razdoblje: {sum}");
                Console.WriteLine($"\nUkupan prihod u ovome vremeskom intervalu: {income}");
                
            }
            Console.ReadKey();
        }
    }
}
