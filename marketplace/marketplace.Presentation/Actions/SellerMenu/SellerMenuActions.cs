using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marketplace.Domain.Repsositories;

namespace marketplace.Presentation.Actions.SellerMenu
{
    public class SellerMenuActions
    {
        public static void MenuForSeller(string emailOfLoggedUser)
        {
            var nameOfLoggedUser = SellerRepositories.findingSellerByEmail(emailOfLoggedUser);
            var menuForSeller = true;
            while (menuForSeller)
            {
                Console.Clear();
                Console.WriteLine($"\t\t Dobrodosli {nameOfLoggedUser}\n\n");
                Console.WriteLine("1 - Dodavanje proizvoda\n2 - Pregled svih proizvoda u vlasnistvu\n3 - Pregled ukupne zarade\n" +
                    "4 - Pregled prodanih proizvoda po kategoriji\n5 - Pregled zarade u odredenom vremenskom razdoblju\n6 - Izlazak s racuna");
                Console.Write("Vas odabir:");
                var validInputForMenu = int.TryParse(Console.ReadLine(), out int choiceForSeller);
                switch (choiceForSeller)
                {
                    case 1:
                        {
                            AddingProductAction(emailOfLoggedUser, nameOfLoggedUser);
                            break;
                        }
                    case 2:
                        {
                            ViewAllProductsInPossesion(emailOfLoggedUser);
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
                            menuForSeller = false;
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

        public static void AddingProductAction(string sellerEmail, string sellerName)
        {
            Console.Clear();
            Console.Write("Upisite ime proizvoda:");
            var productName = Console.ReadLine().Trim();
            var nameOfProductExists = SellerRepositories.CheckIfProductExists(productName, sellerEmail);
            while (true)
            {
                if (string.IsNullOrEmpty(productName))
                {
                    Console.WriteLine("Ime proizvoda ne moze biti prazno.");
                    var confirmForName = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                    if (confirmForName)
                    {
                        Console.Write("Upisite ime proizvoda:");
                        productName = Console.ReadLine().Trim();
                    }
                    else
                    {
                        Console.WriteLine("Proces dodavanja proizvoda je prekinut.");
                        Console.ReadKey();
                        return;
                    }
                }
                else if (nameOfProductExists)
                {
                    Console.WriteLine("Proizvod vec postoji.");
                    var confirmForName = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                    if (confirmForName)
                    {
                        Console.Write("Upisite ime proizvoda:");
                        productName = Console.ReadLine().Trim();
                        nameOfProductExists = SellerRepositories.CheckIfProductExists(productName, sellerEmail);
                    }
                    else
                    {
                        Console.WriteLine("Proces dodavanja proizvoda je prekinut.");
                        Console.ReadKey();
                        return;
                    }
                }
                else
                {
                    break;
                }
            }

            Console.Write("Upisite opis proizvoda:");
            var productDescription = Console.ReadLine().Trim();

            Console.Write("Upisite cijenu proizvoda:");
            var inputForPrice = float.TryParse(Console.ReadLine(), out float productPrice);
            while (true)
            {
                if (productPrice >= 0 && inputForPrice)
                {
                    break;
                }
                else if (productPrice < 0)
                {
                    Console.WriteLine("Molimo vas unesite pozitivan iznos.");
                    var confirmForBalance = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                    if (confirmForBalance)
                    {
                        Console.Write("Upisite cijenu proizvoda:");
                        inputForPrice = float.TryParse(Console.ReadLine(), out productPrice);
                    }
                    else
                    {
                        Console.WriteLine("Proces dodavanja proizvoda je prekinut.");
                        Console.ReadKey();
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Molimo vas unesite brojcanu vrijednost.");
                    var confirmForBalance = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                    if (confirmForBalance)
                    {
                        Console.Write("Upisite cijenu proizvoda:");
                        inputForPrice = float.TryParse(Console.ReadLine(), out productPrice);
                    }
                    else
                    {
                        Console.WriteLine("Proces dodavanja proizvoda je prekinut.");
                        Console.ReadKey();
                        return;
                    }
                }
            }

            Console.Write("Upisite kategoriju proizvoda:");
            var productCategory = Console.ReadLine().Trim();
            while (string.IsNullOrEmpty(productCategory))
            {
                Console.WriteLine("Kategorija ne moze biti prazna.");
                var confirmForCategory = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                if (confirmForCategory)
                {
                    Console.Write("Upisite kategoriju proizvoda:");
                    productCategory = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Proces dodavanja proizvoda je prekinut.");
                    Console.ReadKey();
                    return;
                }
            }

            Domain.Repsositories.SellerRepositories.AddingProduct(sellerEmail, productName, productDescription, productPrice, productCategory);
            Console.WriteLine("Uspjesno dodan prozivod");
            Console.WriteLine($"Detalji dodanog prozivoda su:"); //dodaj porukeda se nesto dodalo i ispsisi to stase dodalo ne samo za ovo nego i  za sve ostalo
        }

        public static void ViewAllProductsInPossesion(string sellerEmail)
        {
            Console.Clear();
            Domain.Repsositories.SellerRepositories.ViewAllProductsInPossesion(sellerEmail);
        }
            
    }
}
