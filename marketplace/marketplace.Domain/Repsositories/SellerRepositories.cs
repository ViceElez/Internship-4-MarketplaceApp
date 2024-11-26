using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using marketplace.Data.Models;
using marketplace.Data.Models.Items;
using marketplace.Data.Models.Users;
using marketplace.Data.Seed;

namespace marketplace.Domain.Repsositories
{
    public class SellerRepositories
    {

        public static string findingSellerByEmail(string sellerEmail)
        {
            var foundSeller = false;
            foreach (seller seller in Seed.Sellers)
            {
                if (seller.Email == sellerEmail)
                {
                    foundSeller = true;
                    return seller.Name;
                }
            }
            if(!foundSeller)
            {
                return null;
            }
            else
            {
                return null;
            }
        }
        public static void AddSeller(string sellerName,string sellerEmail)
        {
            seller newSeller = new seller(sellerName, sellerEmail);
            Seed.Sellers.Add(newSeller);
        }

        public static bool CheckIfProductExists(string itemName,string sellerEmail)
        {
            var foundProduct= false;
            foreach (var seller in Seed.Sellers)
            {
                if (seller.Email == sellerEmail)
                {
                    foreach (var item in seller.Products)
                    {
                        if (item.Name.ToLower() == itemName.ToLower())
                        {
                            foundProduct = true;
                            return true;
                        }
                    }
                }
            }
            if(!foundProduct)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public static void AddingProduct(string sellerEmail, string prdouctName,string productDescription, float productPrice, string productCategory )
        {
            Items newItem = new Items(prdouctName, productDescription, productPrice, productCategory, Seed.Sellers.FirstOrDefault(x => x.Email == sellerEmail));
            Seed.Sellers.FirstOrDefault(x => x.Email == sellerEmail).Products.Add(newItem);
            Console.WriteLine("Uspjesno dodan novi proizvod:");
            Console.WriteLine($"{prdouctName} {productDescription} {newItem.Status} {productPrice} {productCategory} {newItem.SellerOfItem.Name} {newItem.Rating} ");
            Console.ReadKey();
        }

        public static void ViewAllProductsInPossesion(string sellerEmail) 
        {
            var foundItems = false;
            foreach (var seller in Seed.Sellers)
            {
                if (seller.Email == sellerEmail)
                {
                    foreach (var item in seller.Products)
                    {
                        foundItems = true;
                        Console.WriteLine($"Ime proizvoda:{item.Name}\nOpis proizvoda:{item.Description}\nCijena proizvoda:{item.Price}\n" +
                            $"Status proizvoda: {item.Status}\nKategorija proizvoda:{item.Category}\nRating proizvoda:{item.Rating}");
                        Console.WriteLine();
                    }
                }
            }
            if(!foundItems)
            {
                Console.WriteLine("Nemate proizvoda u posjedu.");
                Console.ReadKey();
                return;
            }
            Console.ReadKey();

        }
    }
}
