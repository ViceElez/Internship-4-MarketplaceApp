using marketplace.Presentation.Actions.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marketplace.Presentation
{
    public class Program
    {
        static void Main(string[] args)
        {
            string decorativeLine = new string('-', 30);
            Console.WriteLine(decorativeLine);
            Console.WriteLine("\tDOBRODOSLI");
            Console.WriteLine(decorativeLine);
            Console.WriteLine("Pritisnite bilo koju tipku za nastavak.");
            Console.ReadKey();
            bool menuForLoginAndRegistration = true;
            while (menuForLoginAndRegistration)
            {
                Console.Clear();
                Console.WriteLine("1 - Login\n2 - Registracija\n3 - Izlaz iz aplikacije");
                Console.Write("Vas odabir:");
                var input=int.TryParse(Console.ReadLine(), out int choice);
                switch(choice)
                {
                    case 1:
                        Console.WriteLine("Unesite login ime:");
                        
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Unesite korisnicko ime:");
                        Console.ReadKey();
                        break;
                    case 3:
                        menuForLoginAndRegistration = false;
                        break;
                    default:
                        Console.WriteLine("Pogresan unos.");
                        break;
                }

            }
        }
    }
}
