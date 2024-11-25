using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace marketplace.Presentation.Actions.Login
{
    public class LoginActions
    {
            public  void Login() {
            Console.WriteLine("Unesite ime za login:");
            string loginName = Console.ReadLine();
            while(string.IsNullOrEmpty(loginName))
            {
                Console.WriteLine("Ime nemoze biti prazno.");
                Console.WriteLine("Unesite ime za login:");
                loginName = Console.ReadLine();
            }
            Console.WriteLine("Unesite email:");
            string email = Console.ReadLine();
            while (true)
            {
                if (string.IsNullOrEmpty(email))
                {
                    Console.WriteLine("Email nemoze biti prazan.");
                    Console.WriteLine("Unesite email:");
                    email = Console.ReadLine();
                }
                else if (IsValid(email))
                {
                    Console.WriteLine("Neipsravan email.");
                    Console.WriteLine("Unesite email:");
                    email = Console.ReadLine();
                }
                else
                    break;
            }





        }

        private static bool IsValid(string email)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        }
    }
}
