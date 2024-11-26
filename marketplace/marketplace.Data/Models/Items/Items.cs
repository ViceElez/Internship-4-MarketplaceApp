using marketplace.Data.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marketplace.Data.Models.Items
{
    public class Items
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public seller SellerOfItem { get; set; }
        public float Rating { get; set; }

        public Items(string name, seller seller)
        {
            Id = Guid.NewGuid();
            Name = name;  //saljem name jer cu provjeravat u funkicji jeli to vec postoji

            Console.Write("Upisite opis proizvoda:");
            Description = Console.ReadLine();

            Console.Write("Upisite cijenu proizvoda:");
            var inputForPrice=float.TryParse(Console.ReadLine(), out float price);
            while (!inputForPrice)
            {
                Console.WriteLine("Cijena mora biti broj.");
                var confirmForPrice = ConfirmAndDelete();
                if (confirmForPrice)
                {
                    Console.WriteLine("Upisite cijenu proizvoda:");
                    inputForPrice = float.TryParse(Console.ReadLine(), out price);
                }
                else
                {
                    Console.WriteLine("Proces kreiranja je prekinut.");
                    Console.ReadKey();
                    return;
                }
            }
            Price = price;
            Console.Write("Odaberite status proizvoda(na prodaju/prodano):");
            Status = Console.ReadLine().ToLower().Trim();
            while (Status != "na prodaju" && Status != "prodano")
            {
                Console.WriteLine("Molimo vas unesite ispravan status.");
                var confirmForStatus = ConfirmAndDelete();
                if (confirmForStatus)
                {
                    Console.Write("Odaberite status proizvoda(na prodaju/prodano):");
                    Status = Console.ReadLine().ToLower().Trim();
                }
                else
                {
                    Console.WriteLine("Proces kreiranja je prekinut.");
                    Console.ReadKey();
                    return;
                }
            }
            Console.Write("Odaberite kategoriju proizvoda:");
            Category = Console.ReadLine();
            while (string.IsNullOrEmpty(Category))
            {
                Console.WriteLine("Kategorija ne moze biti prazna.");
                var confirmForCategory = ConfirmAndDelete();
                if (confirmForCategory)
                {
                    Console.Write("Odaberite kategoriju proizvoda:");
                    Category = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Proces kreiranja je prekinut.");
                    Console.ReadKey();
                    return;
                }
            }
            SellerOfItem = seller;
            Rating = 0.00f;
        }

        public Items(string name, string description, float price, string status, string category, seller sellerOfItem, float rating)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            Status = status;
            Category = category;
            SellerOfItem = sellerOfItem;
            Rating = rating;
        }

        public bool ConfirmAndDelete()
        {
            var answer = string.Empty;
            while (true)
            {
                Console.Write("Dali zelite nastaviti (da) ili odustati (ne): ");
                answer = Console.ReadLine()?.ToLower().Trim();

                if (answer == "da")
                {
                    return true;
                }
                else if (answer == "ne")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Krivi unos.");
                }
            }

        }
    }
}
