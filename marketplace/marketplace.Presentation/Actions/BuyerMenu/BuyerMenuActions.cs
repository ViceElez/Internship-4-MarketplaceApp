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
                            ListAllAvailableProductsAction();
                            break;
                        }
                    case 2:
                        {
                            BuyingProductAction(emailOfLoggedUser);
                            break;
                        }
                    case 3:
                        {
                            RefundingProductAction(emailOfLoggedUser);
                            break;
                        }
                    case 4:
                        {
                            AddingItemToFavouriteAction(emailOfLoggedUser);
                            break;
                        }
                    case 5:
                        {
                            ListAllFavouriteProducts(emailOfLoggedUser);
                            break;
                        }
                    case 6:
                        {
                            ListAllBuyersProducts(emailOfLoggedUser);
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

        public static void ListAllAvailableProductsAction()
        {
            Domain.Repsositories.BuyerRepository.ListAllAvailableProducts();
            Console.ReadKey();
        }

        public static void BuyingProductAction(string emailOfLoggedUser)
        {
            var checkForProducts = Domain.Repsositories.BuyerRepository.DoProductsExisist();
            if (checkForProducts == 2)
            {
                Console.WriteLine("Liste dostupnih proizvoda:");
                Domain.Repsositories.BuyerRepository.ListAllAvailableProducts();
                Console.Write("Unesite ID proizvoda koji zelite kupiti:");
                var validInputForId = Guid.TryParse(Console.ReadLine(), out var idOfProduct);
                while (!validInputForId)
                {
                    Console.WriteLine("Krivi unos.");
                    var confirmForId = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                    if (confirmForId)
                    {
                        Console.Write("Unesite ID proizvoda koji zelite kupiti:");
                        validInputForId = Guid.TryParse(Console.ReadLine(), out idOfProduct);
                    }
                    else
                    {
                        Console.WriteLine("Proces kupovine je prekinut.");
                        Console.ReadKey();
                        return;
                    }
                }
                Domain.Repsositories.BuyerRepository.BuyingProduct(emailOfLoggedUser, idOfProduct);
            }
            else if (checkForProducts == 1)
            {
                Console.WriteLine("Nema dostupnih proizvoda.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Nema prodavaca.");
                Console.ReadKey();
            }

        }

        public static void RefundingProductAction(string emailOfLoggedUser)
        {
            Console.Clear();
            if (Domain.Repsositories.BuyerRepository.DoesBuyerHaveProducts(emailOfLoggedUser))
            {
                Console.WriteLine("Liste dostupnih proizvoda za povratak:");
                Domain.Repsositories.BuyerRepository.ListAllBuyersProducts(emailOfLoggedUser);
                Console.Write("Unesite ID proizvoda kojeg zelite vratiti:");
                var validInputForId = Guid.TryParse(Console.ReadLine(), out var idOfProduct);
                while (!validInputForId)
                {
                    Console.WriteLine("Krivi unos.");
                    var confirmForId = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                    if (confirmForId)
                    {
                        Console.Write("Unesite ID proizvoda koji zelite kupiti:");
                        validInputForId = Guid.TryParse(Console.ReadLine(), out idOfProduct);
                    }
                    else
                    {
                        Console.WriteLine("Proces kupovine je prekinut.");
                        Console.ReadKey();
                        return;
                    }
                }
                Domain.Repsositories.BuyerRepository.RefundingASpecificProduct(emailOfLoggedUser, idOfProduct);
            }
            else
            {
                Console.WriteLine("Nema kupljenih proizvoda.");
                Console.ReadKey();
            }
        }

        public static void AddingItemToFavouriteAction(string emailOfLoggedUser)
        {
            Console.Clear();
            if (Domain.Repsositories.BuyerRepository.DoesBuyerHaveProducts(emailOfLoggedUser))
            {
                Console.WriteLine("Liste dostupnih proizvoda za dodavanje u listu omiljenih:");
                Domain.Repsositories.BuyerRepository.ListAllBuyersProducts(emailOfLoggedUser);
                Console.Write("Unesite ID proizvoda kojeg zelite dodati u listu omiljenih:");
                var validInputForId = Guid.TryParse(Console.ReadLine(), out var idOfProduct);
                while (!validInputForId)
                {
                    Console.WriteLine("Krivi unos.");
                    var confirmForId = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                    if (confirmForId)
                    {
                        Console.Write("Unesite ID proizvoda koji zelite kupiti:");
                        validInputForId = Guid.TryParse(Console.ReadLine(), out idOfProduct);
                    }
                    else
                    {
                        Console.WriteLine("Proces kupovine je prekinut.");
                        Console.ReadKey();
                        return;
                    }
                }
                Domain.Repsositories.BuyerRepository.AddingItemToFavourite(emailOfLoggedUser, idOfProduct);
            }
            else
            {
                Console.WriteLine("Nema kupljenih proizvoda.");
                Console.ReadKey();
            }
        }

        public static void ListAllFavouriteProducts(string emailOfLoggedUser)
        {
            Console.Clear();
            if (Domain.Repsositories.BuyerRepository.DoesBuyerHaveProducts(emailOfLoggedUser))
            {
                if (Domain.Repsositories.BuyerRepository.DoesBuyerHaveFavouriteProducts(emailOfLoggedUser))
                {
                    Console.WriteLine("Lista omiljenih proizvoda:");
                    Domain.Repsositories.BuyerRepository.ListAllFavouriteProducts(emailOfLoggedUser);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Nema omiljenih proizvoda.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Nema kupljenih proizvoda.");
                Console.ReadKey();
            }
        }

        public static void ListAllBuyersProducts(string emailOfLoggedUser)
        {
            Console.Clear();
            if (Domain.Repsositories.BuyerRepository.DoesBuyerHaveProducts(emailOfLoggedUser))
            {
                Console.WriteLine("Lista kupljenih proizvoda:");
                Domain.Repsositories.BuyerRepository.ListAllBuyersProducts(emailOfLoggedUser);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Nema kupljenih proizvoda.");
                Console.ReadKey();
            }
        }
    }
}
