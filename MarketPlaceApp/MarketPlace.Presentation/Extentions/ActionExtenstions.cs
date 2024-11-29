using MarketPlace.Presentation.Abstractions;
using MarketPlace.Presentation.Actions;
using MarketPlace.Presentation.Helpers;
using MarketPlace.Presentation.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using MarketPlace.Data.Entities.models;

namespace MarketPlace.Presentation.Extentions
{
    public static class ActionExtensions
    {
        public static void PrintActionsAndOpen(this IList<IAction> actions)
        {
            const string INVALID_INPUT_MSG = "Please type in number!";
            const string INVALID_ACTION_MSG = "Please select valid action!";

            var isExitSelected = false;

            do
            {
                PrintActions(actions);

                var isValidInput = int.TryParse(Console.ReadLine(), out var actionIndex);
                if (!isValidInput)
                {
                    Console.WriteLine("Unesite broj");
                    Console.ReadKey();
                    continue;
                }

                var action = actions.FirstOrDefault(a => a.MenuIndex == actionIndex);
                if (action is null)
                {
                    Console.WriteLine("Odabrana akcija nepostoji");
                    Console.ReadKey();
                    continue;
                }
                action.Open();

                isExitSelected = action is ExitMenuAction;

            } while (!isExitSelected);
        }

        public static void SetActionIndexes(this IList<IAction> actions)
        {
            var index = 0;
            foreach (var action in actions)
            {
                action.MenuIndex = ++index;
            }
        }

        public static void PrintActions()
        {
            var homepageActions = HomepageFactory.CreateActions();
            homepageActions.PrintActionsAndOpen();
        }

        public static void PrintBuyerActions(Buyer buyer)
        {
            var buyerMainMenuActions = BuyerMainMenu.CreateActions(buyer);
            buyerMainMenuActions.PrintActionsAndOpen();
        }

        public static void PrintMerchantActions(Merchant merchant)
        {
            var merchantMainMenuActions = MerchantMainMenu.CreateActions(merchant);
            merchantMainMenuActions.PrintActionsAndOpen();
        }
        private static void PrintActions(IList<IAction> actions)
        {
            Console.Clear();

            foreach (var action in actions)
            {
                Console.WriteLine($"{action.MenuIndex}. {action.Name}");
            }
        }


        public static string CorrectEmailChoice()
        {
            string? email = Reader.ReadInput();
            while (email == null)
            {
                bool cont = Reader.DoYouWantToContinue();
                if (cont)
                    email = EmailChoice();
                else
                    PrintActions();
            }
            return email;
        }

        public static string? EmailChoice()
        {
            Console.Clear();
            string? email = Reader.ReadInput();
            return email;
        }
    }
}
