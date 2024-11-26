using marketplace.Domain.Repsositories;
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
        public static void Login()
        {
            Console.Clear();
            Console.Write("Unesite email za login:");
            var loginEmail = Console.ReadLine().Trim();
            while (true)
            {
                if (string.IsNullOrEmpty(loginEmail))
                {
                    Console.WriteLine("Email nemoze biti prazan.");
                    var confirmForEmail = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                    if (confirmForEmail)
                    {
                        Console.Write("Unesite email:");
                        loginEmail = Console.ReadLine().Trim();
                    }
                    else
                    {
                        Console.WriteLine("Proces logiranja je prekinut.");
                        Console.ReadKey();
                        return;
                    }
                }
                else if (!Helper.ChecksIfInputIsValid.IsValid(loginEmail))
                {
                    Console.WriteLine("Neipsravan format email-a.");
                    var confirmForEmail = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                    if (confirmForEmail)
                    {
                        Console.Write("Unesite email:");
                        loginEmail = Console.ReadLine().Trim();
                    }
                    else
                    {
                        Console.WriteLine("Proces logiranja je prekinut.");
                        Console.ReadKey();
                        return;
                    }
                }
                else
                    break;
            }
            while (true)
            {
                var checkIfUserExists = Domain.Repsositories.CheckingForInputs.CheckIfUserExists(loginEmail);
                if (!checkIfUserExists)
                {
                    Console.WriteLine("Korisnik s tim emailom ne postoji.");
                    var confirmForEmail = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                    if (confirmForEmail)
                    {
                        Console.Write("Unesite email:");
                        loginEmail = Console.ReadLine().Trim();
                    }
                    else
                    {
                        Console.WriteLine("Proces logiranja je prekinut.");
                        Console.ReadKey();
                        return;
                    }
                }
                else
                    break;
            }
            var checkRoleOfUser = Domain.Repsositories.CheckingForInputs.CheckRoleOfUser(loginEmail);
            if (checkRoleOfUser == "buyer")
            {
                Console.WriteLine($"Uspjesno ste se logirali kao kupac.");
                Presentation.Actions.BuyerMenu.BuyerMenuActions.MenuForBuyer(loginEmail);
                return;
            }
            else
            {
                Console.WriteLine("Uspjesno ste se logirali kao prodavac.");
                Presentation.Actions.SellerMenu.SellerMenuActions.MenuForSeller(loginEmail);
                return;
            }
        }
    }
}
