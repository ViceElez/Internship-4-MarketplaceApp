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

        public static void TotalProfit(string sellerEmail)
        {
            Console.Clear();
            var sellersProfit = Domain.Repsositories.SellerRepositories.TotalProfitForSeller(sellerEmail);
            if(sellersProfit<0)
                Console.WriteLine("Lista proizvoda je prazna");
            else
                Console.WriteLine($"Totalna zarada je: {sellersProfit}");
            Console.ReadKey();  
        }

        public static void ListingProductsByDesiredCategory(string sellerEmail) //nenzna jel 100% radi dok ne napravin kupca pa vidin stase desi ako se minja status proizvoda usrid koda
        {
            Console.Clear();
            string desiredCategory=string.Empty;
            if (Domain.Repsositories.SellerRepositories.CheckIfListOfProductsIsEmpty(sellerEmail))
            {
                Console.WriteLine("Prodavac nema proizvoda.");
                return;
            }
            else
            {
                if (Domain.Repsositories.SellerRepositories.CheckIfStatusSoldForCategoryIsEmpty(sellerEmail)){
                    Console.WriteLine("Nema prodanih proizvoda");
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
                Console.Write("Datum od(dd/mm/yyyy):");
                var inputForDateFrom = DateTime.TryParse(Console.ReadLine(), out DateTime dateFrom);
                while (true)
                {
                    if (inputForDateFrom)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Molimo vas unesite datum u formatu dd/mm/yyyy");
                        var confirmForDateFrom = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                        if (confirmForDateFrom)
                        {
                            Console.Write("Datum od:");
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
                Console.Write("Datum do(dd/mm/yyyy):");
                var inputForDateTo = DateTime.TryParse(Console.ReadLine(), out DateTime dateTo);
                while (true)
                {
                    if (inputForDateTo)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Molimo vas unesite datum u formatu dd/mm/yyyy");
                        var confirmForDateTo = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                        if (confirmForDateTo)
                        {
                            Console.Write("Datum do:");
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
        }//triba vidit i jel ovo radi kad se minja status proizvoda usrid koda
    }
}
