﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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

        public static void AddingProduct(string sellerEmail, string productName, string productDescription, double productPrice, string productCategory)
        {
            var seller = Seed.Sellers.FirstOrDefault(x => x.Email == sellerEmail);
            if (seller != null)
            {
                Items newItem = new Items(productName, productDescription, productPrice, productCategory, seller);
                Seed.Items.Add(newItem);
                Console.WriteLine("Uspjesno dodan novi proizvod:");
                Console.WriteLine($"Ime: {productName}\nOpis: {productDescription}\n" +
                    $"Cijena: {Math.Round(productPrice, 2)}\nKategorija: {productCategory}\n" +
                    $"Ime prodavaca:{newItem.SellerOfItem.Name}");
            }
            Console.ReadKey();
        }

        public static void ViewAllProductsInPossesion(string sellerEmail) 
        {
            var foundItems = false;
            var seller = Seed.Sellers.FirstOrDefault(s => s.Email == sellerEmail);
            
                if (seller.Email == sellerEmail)
                {
                    foreach (var item in seller.Products)
                    {
                        foundItems = true;
                        Console.WriteLine($"Id proizvoda:{item.Id}\nIme proizvoda:{item.Name}\nOpis proizvoda:{item.Description}\nCijena proizvoda:{item.Price}\n" +
                            $"Status proizvoda: {item.Status}\nKategorija proizvoda:{item.Category}\n");
                        Console.WriteLine();
                    }
                }
            if(!foundItems)
            {
                Console.WriteLine("Nemate proizvoda u posjedu.");
                return;
            }

        }

        public static double TotalProfitForSeller(string sellerEmail)
        {
            var profitSum = 0.00d;
            var foundItems = false;
            foreach(var seller in Seed.Sellers)
            {
                if(seller.Email == sellerEmail)
                {

                    return seller.currentProfit;
                }
            }
            if (!foundItems)
                return -1;
            
            return profitSum;
        }

        public static void ListAllProductsByDesiredCategory(string sellerEmail, string inputedCategory)
        {
            Console.Clear();
            foreach(var seller in Seed.Sellers)
            {
                if (seller.Email == sellerEmail)
                {
                    foreach(var item in seller.Products)
                    {
                        if(item.Category.ToLower().Trim() == inputedCategory.ToLower().Trim() && item.Status == "prodano")
                        Console.WriteLine($"Ime proizvoda:{item.Name}\nOpis proizvoda: {item.Description}\nCijena proizvoda: {item.Price}");
                        Console.WriteLine();
                    }
                }
            }
            Console.ReadKey();
        }

        public static void ListAllCategoriesOfProducts(string sellerEmail)
        {
            List<string> listedCategories = new List<string>();
            foreach(var seller in Seed.Sellers)
            {
                if (seller.Email == sellerEmail)
                {
                        foreach (var item in seller.Products)
                        {
                            if (!listedCategories.Contains(item.Category.ToLower().Trim()) && item.Status=="prodano")
                            {
                                Console.WriteLine($"Kategorija:{item.Category}");
                                listedCategories.Add(item.Category.ToLower().Trim());
                            }
                        }
                }
            }
        }

        public static bool CheckIfListOfProductsIsEmpty(string sellerEmail)
        {
            foreach (var seller in Seed.Sellers)
            {
                if (seller.Email == sellerEmail)
                {
                    if (seller.Products.Count == 0)
                        return true;
                    
                }
            }
            return false; 
        }

        public static bool CheckIfInputedCategoryExisist(string sellerEmail, string inputedCategory)
        {
            List<string> listedCategories = new List<string>();
            foreach (var seller in Seed.Sellers)
            {
                if (seller.Email == sellerEmail)
                {
                    foreach (var item in seller.Products)
                    {
                        if (!listedCategories.Contains(item.Category.ToLower().Trim()) && item.Status == "prodano")
                        {
                            listedCategories.Add(item.Category.ToLower().Trim());
                        }
                    }
                }
            }

            foreach(var category in listedCategories)
            {
                if (inputedCategory.ToLower().Trim() == category.ToLower().Trim())
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CheckIfStatusSoldForCategoryIsEmpty(string sellerEmail)
        {
            if(CheckIfListOfProductsIsEmpty(sellerEmail))
                return true;
            foreach(var seller in Seed.Sellers)
                {
                    if (seller.Email == sellerEmail)
                    {
                        foreach(var item in seller.Products)
                        {
                            if (item.Status == "prodano")
                                return false;

                        }
                    }
                }
            return true;
        }

        public static void ProfitInCertainTime(string sellerEmail, DateTime dateFrom, DateTime dateTo)
        {
            Console.Clear();
            var profitSum = 0.00d;
            var sellerID= Guid.Empty;
            foreach (var seller in Seed.Sellers)
            {
                if (seller.Email == sellerEmail)
                {
                    sellerID = seller.ID;
                }
            }
            foreach(var transaction in Seed.Transactions)
            {
                if (transaction.TransactionSellerID == sellerID && transaction.DateOfTransaction >= dateFrom && transaction.DateOfTransaction <= dateTo)
                {
                    profitSum += transaction.Amount;
                }
            }
            Console.WriteLine($"Ukupan profit u periodu od {dateFrom} do {dateTo} je: {Math.Round(profitSum,2)}");
            Console.ReadKey();
        }

        public static void ChangePriceOfProduct(string sellerEmail, Guid productID, double newPrice)
        {
            foreach (var seller in Seed.Sellers)
            {
                if (seller.Email == sellerEmail)
                {
                    foreach (var item in seller.Products)
                    {
                        if (item.Id == productID && item.Status=="na prodaju")
                        {
                            item.Price = newPrice;
                            Console.WriteLine("Cijena proizvoda je promjenjena.");
                            Console.ReadKey();
                            return;
                        }
                    }
                }
            }
            Console.WriteLine("Proizvod nije pronadjen.");
            Console.ReadKey();
        }

        public static void ListAllProductsThatAreOnSale(string sellerEmail)
        {
            Console.Clear();
            foreach (var seller in Seed.Sellers)
            {
                if (seller.Email == sellerEmail)
                {
                    foreach (var item in seller.Products)
                    {
                        if (item.Status == "na prodaju")
                        {
                            Console.WriteLine($"Id: {item.Id}\nIme: {item.Name}\nOpis: {item.Description}\nCijena: {item.Price}");
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
