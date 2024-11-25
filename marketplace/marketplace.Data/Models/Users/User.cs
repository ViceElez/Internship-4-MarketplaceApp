using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace marketplace.Data.Models.Users
{
    public class User
    {
        public Guid ID { get; set; }
        protected string Name { get; set; }
        protected string Email { get; set; }

        public User(string name, string email)
        {
            ID = Guid.NewGuid();
            Name = name;
            Email = email;
        }
        public User()
        {
            ID = Guid.NewGuid();
            Console.WriteLine("Upisite ime korisnika");
            Name= Console.ReadLine();
            while(string.IsNullOrEmpty(Name))
            {
                Console.WriteLine("Ime ne moze biti prazno");
                var confirmForName = ConfirmAndDelete();
                if (confirmForName)
                {
                    Console.WriteLine("Upisite ime korisnika");
                    Name = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Proces kreiranja je zavrsio.");
                    Console.ReadKey();
                    return;
                }

            }
            Console.WriteLine("Upisite email korisnika");
            Email = Console.ReadLine();
            while (true)
            {
                if (string.IsNullOrEmpty(Email))
                {
                    Console.WriteLine("Email nemoze biti prazan.");
                    var confirmForEmail = ConfirmAndDelete();
                    if (confirmForEmail)
                    {
                        Console.WriteLine("Unesite email:");
                        Email = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Proces kreiranja je zavrsio.");
                        Console.ReadKey();
                        return;
                    }
                }
                else if (IsValid(Email))
                {
                    Console.WriteLine("Neipsravan format email-a.");
                    var confirmForEmail = ConfirmAndDelete();
                    if (confirmForEmail)
                    {
                        Console.WriteLine("Unesite email:");
                        Email = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Proces kreiranja je zavrsio.");
                        Console.ReadKey();
                        return;
                    }
                }
                else
                    break;
            }

        }

        public bool IsValid(string email)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        }

        public bool ConfirmAndDelete() {
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
