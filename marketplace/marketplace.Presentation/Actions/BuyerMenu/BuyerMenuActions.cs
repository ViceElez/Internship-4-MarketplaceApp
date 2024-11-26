using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marketplace.Domain.Repsositories;

namespace marketplace.Presentation.Actions.BuyerMenu
{
    public class BuyerMenuActions
    {
        public static void MenuForBuyer(string emailOfLoggedUser)
        {
            var nameOfLoggedUser = BuyerRepository.FindingBuyerByEmail(emailOfLoggedUser);
            var menuForBuyer = true;
            while (menuForBuyer)
            {
                Console.Clear();
                Console.WriteLine($"\t\t Dobrodosli {nameOfLoggedUser}\n\n");
                Console.WriteLine("1 - Pregled svih dostupnih proizvoda \n2 - Kupovina proizvoda\n3 - Povratak kupljenih proizvoda\n" +
                    "4 - Dodavanje proizvoda u listu omiljenih\n5 - Pregled liste omiljenih proizvoda\n" +
                    "6 - Pregled kupljenih proizvoda\n7 - Izlazak s racuna");
                Console.Write("Vas odabir:");
                var validInputForMenu = int.TryParse(Console.ReadLine(), out int choiceForBuyer);
                switch (choiceForBuyer)
                {
                    case 1:
                        {
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    case 3:
                        {
                            break;
                        }
                    case 4:
                        {
                            break;
                        }
                    case 5:
                        {
                            break;
                        }
                    case 6:
                        {
                            break;
                        }
                    case 7:
                        {
                            menuForBuyer = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Pogresan unos.");
                            Console.ReadKey();
                            break;
                        }
                     }
             }
        }
    }
}
