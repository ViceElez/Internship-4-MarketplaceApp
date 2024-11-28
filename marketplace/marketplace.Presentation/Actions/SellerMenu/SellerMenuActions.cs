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
                    "4 - Pregled prodanih proizvoda po kategoriji\n5 - Pregled zarade u odredenom vremenskom razdoblju\n" +
                    "6 - Mjenjanje cijene proizvoda\n7 - Izlazak s racuna");
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
                            TotalProfit(emailOfLoggedUser);
                            break;
                        }
                    case 4:
                        {
                            ListingProductsByDesiredCategory(emailOfLoggedUser);
                            break;
                        }
                    case 5:
                        {
                            ProfitInCertainTime(emailOfLoggedUser);
                            break;
                        }
                    case 6:
                        {ChangePriceOfProduct(emailOfLoggedUser);
                            break;
                        }
                    case 7:
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
                else
                {
                    break;
                }
            }

            Console.Write("Upisite opis proizvoda:");
            var productDescription = Console.ReadLine().Trim();

            Console.Write("Upisite cijenu proizvoda:");
            var inputForPrice = double.TryParse(Console.ReadLine(), out double productPrice);
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
                        inputForPrice = double.TryParse(Console.ReadLine(), out productPrice);
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
                        inputForPrice = double.TryParse(Console.ReadLine(), out productPrice);
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
            Console.ReadKey();
        }

        public static void TotalProfit(string sellerEmail)
        {
            Console.Clear();
            var sellersProfit = Domain.Repsositories.SellerRepositories.TotalProfitForSeller(sellerEmail);
            if (sellersProfit < 0)
                Console.WriteLine("Lista proizvoda je prazna");
            else
                Console.WriteLine($"Totalna zarada je: {Math.Round(sellersProfit, 2)}");
            Console.ReadKey();
        }

        public static void ListingProductsByDesiredCategory(string sellerEmail)
        {
            Console.Clear();
            string desiredCategory = string.Empty;
            if (Domain.Repsositories.SellerRepositories.CheckIfListOfProductsIsEmpty(sellerEmail))
            {
                Console.WriteLine("Prodavac nema proizvoda.");
                return;
            }
            else
            {
                if (Domain.Repsositories.SellerRepositories.CheckIfStatusSoldForCategoryIsEmpty(sellerEmail))
                {
                    Console.WriteLine("Nema prodanih proizvoda");
                    Console.ReadKey();
                    return;
                }
                Domain.Repsositories.SellerRepositories.ListAllCategoriesOfProducts(sellerEmail);
                Console.Write("Upisite za koju kategoriju zelite vidjeti proizvode: ");
                desiredCategory = Console.ReadLine();
                while (true)
                {
                    Console.Clear();
                    Domain.Repsositories.SellerRepositories.ListAllCategoriesOfProducts(sellerEmail);
                    if (string.IsNullOrEmpty(desiredCategory))
                    {
                        Console.WriteLine("Odabrana kategorija nemoze biti prazna:");
                        var confirmForCategory = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                        if (confirmForCategory)
                        {
                            Console.Write("Upisite za koju kategorij zelite vidjeti proizvode: ");
                            desiredCategory = Console.ReadLine().Trim();
                        }
                        else
                        {
                            Console.WriteLine("Ispisvanje proizvoda po kategoriji je prekinuto.");
                            Console.ReadKey();
                            return;
                        }
                    }
                    else if (!Domain.Repsositories.SellerRepositories.CheckIfInputedCategoryExisist(sellerEmail, desiredCategory))
                    {
                        Console.WriteLine("Odabrana kategorija nije na listi:");
                        var confirmForCategory = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                        if (confirmForCategory)
                        {
                            Console.Write("Upisite za koju kategoriju zelite vidjeti proizvode: ");
                            desiredCategory = Console.ReadLine().Trim();
                        }
                        else
                        {
                            Console.WriteLine("Ispisvanje proizvoda po kategoriji je prekinuto");
                            Console.ReadKey();
                            return;
                        }
                    }

                    else
                        break;
                }
            }

            Domain.Repsositories.SellerRepositories.ListAllProductsByDesiredCategory(sellerEmail, desiredCategory);
        }

        public static void ProfitInCertainTime(string sellerEmail)
        {
            Console.Clear();
            if (Domain.Repsositories.SellerRepositories.CheckIfListOfProductsIsEmpty(sellerEmail))
            {
                Console.WriteLine("Prodavac nema proizvoda.");
                return;
            }
            else
            {
                Console.WriteLine("Upisite datum od i do kada zelite vidjeti zaradu:");
                Console.Write("Datum od(mm/dd/yyyy):");
                var inputForDateFrom = DateTime.TryParse(Console.ReadLine(), out DateTime dateFrom);
                while (true)
                {
                    if (inputForDateFrom)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Molimo vas unesite datum u formatu (mm/dd/yyyy)");
                        var confirmForDateFrom = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                        if (confirmForDateFrom)
                        {
                            Console.Write("Datum od(mm/dd/yyyy):");
                            inputForDateFrom = DateTime.TryParse(Console.ReadLine(), out dateFrom);
                        }
                        else
                        {
                            Console.WriteLine("Proces pregleda zarade u odredenom vremenskom razdoblju je prekinut.");
                            Console.ReadKey();
                            return;
                        }
                    }
                }
                Console.Write("Datum do(mm/dd/yyyy):");
                var inputForDateTo = DateTime.TryParse(Console.ReadLine(), out DateTime dateTo);
                while (true)
                {
                    if (inputForDateTo)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Molimo vas unesite datum u formatu (mm/dd/yyyy)");
                        var confirmForDateTo = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                        if (confirmForDateTo)
                        {
                            Console.Write("Datum do(mm/dd/yyyy):");
                            inputForDateTo = DateTime.TryParse(Console.ReadLine(), out dateTo);
                        }
                        else
                        {
                            Console.WriteLine("Proces pregleda zarade u odredenom vremenskom razdoblju je prekinut.");
                            Console.ReadKey();
                            return;
                        }
                    }
                }
                Domain.Repsositories.SellerRepositories.ProfitInCertainTime(sellerEmail, dateFrom, dateTo);
            }
        }//nezeli radit

        public static void ChangePriceOfProduct(string sellerEmail)
        {
            Console.Clear();
            var idOfProduct = Guid.Empty;
            var newPrice = 0.00d;
            if (Domain.Repsositories.SellerRepositories.CheckIfListOfProductsIsEmpty(sellerEmail))
            {
                Console.WriteLine("Prodavac nema proizvoda.");
                Console.ReadKey();
                return;
            }
            else
            {
                Domain.Repsositories.SellerRepositories.ViewAllProductsInPossesion(sellerEmail);
                Console.Write("Upisite ID proizvoda kojem zelite zamijeniti cijenu:");
                var validInputForId = Guid.TryParse(Console.ReadLine(), out  idOfProduct);
                while (true)
                {
                    if (validInputForId)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Molimo vas unesite ispravan ID proizvoda.");
                        var confirmForId = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                        if (confirmForId)
                        {
                            Console.Write("Upisite ID proizvoda kojem zelite zamijeniti cijenu:");
                            validInputForId = Guid.TryParse(Console.ReadLine(), out idOfProduct);
                        }
                        else
                        {
                            Console.WriteLine("Proces zamjene cijene proizvoda je prekinut.");
                            Console.ReadKey();
                            return;
                        }
                    }
                }

                Console.Write("Upisite novu cijenu prozivoda:");
                var inputForPrice = double.TryParse(Console.ReadLine(), out  newPrice);
                while (true)
                {
                    if (newPrice >= 0 && inputForPrice)
                    {
                        break;
                    }
                    else if (newPrice < 0)
                    {
                        Console.WriteLine("Molimo vas unesite pozitivan iznos.");
                        var confirmForBalance = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                        if (confirmForBalance)
                        {
                            Console.Write("Upisite novu cijenu proizvoda:");
                            inputForPrice = double.TryParse(Console.ReadLine(), out newPrice);
                        }
                        else
                        {
                            Console.WriteLine("Proces zamjene cijene proizvoda je prekinut.");
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
                            Console.Write("Upisite novu cijenu proizvoda:");
                            inputForPrice = double.TryParse(Console.ReadLine(), out newPrice);
                        }
                        else
                        {
                            Console.WriteLine("Proces zamjene cijene proizvoda je prekinut.");
                            Console.ReadKey();
                            return;
                        }
                    }
                }
            }
            Domain.Repsositories.SellerRepositories.ChangePriceOfProduct(sellerEmail,idOfProduct,newPrice);
        }
    }
}
