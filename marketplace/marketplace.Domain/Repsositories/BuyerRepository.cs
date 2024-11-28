﻿using marketplace.Data.Models;
using marketplace.Data.Models.Items;
using marketplace.Data.Models.Transactions;
using marketplace.Data.Models.Users;
using marketplace.Data.Seed;    
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marketplace.Domain.Repsositories
{
    public class BuyerRepository
    {
        public static string FindingBuyerByEmail(string buyerEmail)
        {
            var foundBuyer = false;
            foreach (buyer buyer in Seed.Buyers)
            {
                if (buyer.Email == buyerEmail)
                {
                    foundBuyer = true;
                    return buyer.Name;
                }
            }
            if (!foundBuyer)
            {
                return null;
            }
            else
            {
                return null;
            }
        }
        public static void AddBuyer(string buyerName, string buyerEmail, float buyerBalance)
        {
            buyer newBuyer = new buyer(buyerName, buyerEmail, buyerBalance);
            Seed.Buyers.Add(newBuyer);
        }

        public static int DoProductsExisist()
        {
            var foundSeller = false;
            var foundProduct = false;
            foreach (var seller in Seed.Sellers)
            {
                foundSeller = true;
                foreach (var product in seller.Products)
                {
                    foundProduct = true;
                }
            }

            if (!foundSeller)
            {
                Console.WriteLine("Nema prodavaca.");
                return 0;
            }


            else if (!foundProduct)
            {
                Console.WriteLine("Nema dostupnih proizvoda.");
                return 1;
            }

            return 2;
        }

        public static void ListAllAvailableProducts()
        {
            Console.Clear();
            var foundProducts = false;
            foreach (var seller in Seed.Sellers)
            {
                foreach (var product in seller.Products)
                {
                    if (product.Status == "na prodaju")
                    {
                        Console.WriteLine($"Id proizvoda:{product.Id}\nIme proizvoda: {product.Name}\n" +
                       $"Cijena: {product.Price}\nOpis: {product.Description}\n");
                        foundProducts = true;
                    }

                }
            }
            if (!foundProducts)
            {
                Console.WriteLine("Nema dostupnih proizvoda.");
            }

        }

        public static void BuyingProduct(string emailOfLoggedUser, Guid idOfLookingItem)
        {
            var foundProduct = false;
            foreach (var seller in Seed.Sellers) //provjri jel radi 
            {
                foreach (var item in seller.Products)
                {
                    if (idOfLookingItem == item.Id)
                    {
                        foundProduct = true;
                        if (item.Price <= Seed.Buyers.Find(b => b.Email == emailOfLoggedUser).currentBalance && item.Status=="na prodaju")
                        {
                            if (DoesBuyerHaveCoupons(emailOfLoggedUser))
                            {
                                foreach (var coupon in Seed.Buyers.Find(b => b.Email == emailOfLoggedUser).Coupons)
                                {
                                    if (item.Category.ToLower().Trim() == coupon.Category.ToLower().Trim())
                                    {
                                        var answer = string.Empty;
                                        while (true)
                                        {
                                            Console.WriteLine("Pronasli smo kupon za ovu kategoriju, biste li ga zeljeli iskoristiti(da/ne)");
                                            answer = Console.ReadLine()?.ToLower().Trim();

                                            if (answer == "da")
                                            {
                                                var discount = item.Price * (coupon.Discount/100);
                                                var payment = item.Price - discount;
                                                Seed.Buyers.Find(b => b.Email == emailOfLoggedUser).currentBalance -= payment;
                                                seller.currentProfit += payment * 0.95;
                                                Seed.Buyers.Find(b => b.Email == emailOfLoggedUser).ItemsBought.Add(item);
                                                Seed.Buyers.Find(b => b.Email == emailOfLoggedUser).Coupons.Remove(coupon);
                                                item.Status = "prodano";
                                                Transactions newTransactionWithCoupon = new Transactions(idOfLookingItem, seller.ID, Seed.Buyers.Find(b => b.Email == emailOfLoggedUser).ID, DateTime.Now, payment);
                                                Seed.Transactions.Add(newTransactionWithCoupon);
                                                Console.WriteLine("Proizvod je uspjesno kupljen.");
                                                Console.ReadKey();
                                                return;
                                            }
                                            else if (answer == "ne")
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Krivi unos.");
                                            }
                                        }
                                        Seed.Buyers.Find(b => b.Email == emailOfLoggedUser).currentBalance -= item.Price;
                                        seller.currentProfit += item.Price * 0.95;
                                        Seed.Buyers.Find(b => b.Email == emailOfLoggedUser).ItemsBought.Add(item);
                                        item.Status = "prodano";
                                        Transactions newTransaction = new Transactions(idOfLookingItem, seller.ID, Seed.Buyers.Find(b => b.Email == emailOfLoggedUser).ID, DateTime.Now, item.Price);
                                        Seed.Transactions.Add(newTransaction);
                                        Console.WriteLine("Proizvod je uspjesno kupljen.");
                                        Console.ReadKey();
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                if (item.Price >= 100)
                                {
                                    GiveOutARandomCoupon(emailOfLoggedUser);
                                }
                                Seed.Buyers.Find(b => b.Email == emailOfLoggedUser).currentBalance -= item.Price;
                                seller.currentProfit += item.Price * 0.95;
                                Seed.Buyers.Find(b => b.Email == emailOfLoggedUser).ItemsBought.Add(item);
                                item.Status = "prodano";
                                Transactions newTransaction = new Transactions(idOfLookingItem, seller.ID, Seed.Buyers.Find(b => b.Email == emailOfLoggedUser).ID, DateTime.Now, item.Price);
                                Seed.Transactions.Add(newTransaction);
                                Console.WriteLine("Proizvod je uspjesno kupljen.");
                                Console.ReadKey();
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nemate dovoljno sredstava.");
                            Console.ReadKey();
                        }
                    }
                }
            }
            if (!foundProduct)
            {
                Console.WriteLine("Proizvod s tim id-om nije pronadjen.");
                Console.ReadKey();
            }
        }

        public static bool DoesBuyerHaveProducts(string emailOfLoggedUser)
        {
            foreach (var buyer in Seed.Buyers)
            {
                if (buyer.Email == emailOfLoggedUser)
                {
                    foreach (var item in buyer.ItemsBought)
                    {
                        return true;
                    }
                }
            }
            return false;

        }

        public static void ListAllBuyersProducts(string emailOfLoggedUser)
        {
            foreach (var buyer in Seed.Buyers)
            {
                if (buyer.Email == emailOfLoggedUser)
                {
                    foreach (var item in buyer.ItemsBought)
                    {
                        Console.WriteLine($"Id proizvoda:{item.Id}\nIme proizvoda: {item.Name}\n" +
                       $"Cijena: {item.Price}\nOpis: {item.Description}\n");
                        Console.WriteLine();
                    }
                }
            }
        }

        public static void RefundingASpecificProduct(string emailOfLoggedUser, Guid idOfLookingItem)
        {
            var foundProduct = false;
            foreach (var buyer in Seed.Buyers)
            {
                if (buyer.Email == emailOfLoggedUser)
                {
                    foreach (var item in buyer.ItemsBought)
                    {
                        if (item.Id == idOfLookingItem)
                        {
                            foundProduct = true;
                            var transactionToRemove = Seed.Transactions.FirstOrDefault(
                             t => t.IdOfItem == idOfLookingItem && t.TransactionBuyerID == buyer.ID);
                            buyer.currentBalance += transactionToRemove.Amount;
                            item.Status = "na prodaju";
                            buyer.ItemsBought.Remove(item);
                            var seller = Seed.Sellers.Find(s => s.ID == item.SellerOfItem.ID);
                            seller.currentProfit -= transactionToRemove.Amount * 0.95;

                            if (transactionToRemove != null)
                            {
                                Seed.Transactions.Remove(transactionToRemove);
                            }

                            Console.WriteLine("Proizvod je uspješno vraćen.");
                            Console.ReadKey();
                            return;
                        }
                    }
                }
                if (!foundProduct)
                {
                    Console.WriteLine("Proizvod s tim id-om nije pronadjen.");
                    Console.ReadKey();
                    return;
                }
            }
        }

        public static void AddingItemToFavourite(string emailOfLoggedUser, Guid idOfLookingItem)
        {
            foreach (var buyer in Seed.Buyers)
            {
                if (buyer.Email == emailOfLoggedUser)
                {
                    foreach (var item in buyer.ItemsBought)
                    {
                        if (item.Id == idOfLookingItem)
                        {
                            buyer.FavouriteItems.Add(item);
                            Console.WriteLine("Proizvod je uspjesno dodan u listu omiljenih.");
                            Console.ReadKey();
                        }
                    }
                }


            }
        }

        public static void ListAllFavouriteProducts(string emailOfLoggedUser)
        {
            foreach (var buyer in Seed.Buyers)
            {
                if (buyer.Email == emailOfLoggedUser)
                {
                    foreach (var item in buyer.FavouriteItems)
                    {
                        Console.WriteLine($"Id proizvoda:{item.Id}\nIme proizvoda: {item.Name}\n" +
                       $"Cijena: {item.Price}\nOpis: {item.Description}\n");
                        Console.WriteLine();
                    }
                }
            }
        }

        public static bool DoesBuyerHaveFavouriteProducts(string emailOfLoggedUser)
        {
            foreach (var buyer in Seed.Buyers)
            {
                if (buyer.Email == emailOfLoggedUser)
                {
                    foreach (var item in buyer.FavouriteItems)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool DoesBuyerHaveCoupons(string emailOfLoggedUser)
        {
            foreach (var buyer in Seed.Buyers)
            {
                if (buyer.Email == emailOfLoggedUser)
                {
                    foreach (var coupon in buyer.Coupons)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static void GiveOutARandomCoupon(string emailOfLoggedUser)
        {
            var random = new Random();
            var randomNumber = random.Next(0, Seed.Coupons.Count);
            Seed.Buyers.Find(b => b.Email == emailOfLoggedUser).Coupons.Add(Seed.Coupons[randomNumber]);
            Console.WriteLine("Dobili ste kupon.");
            Console.ReadKey();
        }
    } 
}
