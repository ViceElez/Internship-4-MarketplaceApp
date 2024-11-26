using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace marketplace.Presentation.Actions.SingIn
{
    public class SignInActions
    {
        public static void SignInBuyer()
        {
            Console.Clear();
            Console.Write("Unesite ime za registraciju:");
            var registrationName = Console.ReadLine().Trim();
            while (string.IsNullOrEmpty(registrationName))
            {
                Console.WriteLine("Ime nemoze biti prazno.");
                var confirmForName = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                if (confirmForName)
                {
                    Console.Write("Unesite ime za registraciju:");
                    registrationName = Console.ReadLine().Trim();
                }
                else
                {
                    Console.WriteLine("Proces registriranja je prekinut.");
                    Console.ReadKey();
                    return;
                }

            }

            Console.Write("Unesite email za registraciju:");
            var registrationEmail = Console.ReadLine().Trim();
            while (true)
            {
                if (string.IsNullOrEmpty(registrationEmail))
                {
                    Console.WriteLine("Email nemoze biti prazan.");
                    var confirmForEmail = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                    if (confirmForEmail)
                    {
                        Console.Write("Unesite email:");
                        registrationEmail = Console.ReadLine().Trim();
                    }
                    else
                    {
                        Console.WriteLine("Proces registracije je prekinut.");
                        Console.ReadKey();
                        return;
                    }
                }
                else if (!Helper.ChecksIfInputIsValid.IsValid(registrationEmail))
                {
                    Console.WriteLine("Neipsravan format email-a.");
                    var confirmForEmail = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                    if (confirmForEmail)
                    {
                        Console.Write("Unesite email:");
                        registrationEmail = Console.ReadLine().Trim();
                    }
                    else
                    {
                        Console.WriteLine("Proces registracije je prekinut.");
                        Console.ReadKey();
                        return;
                    }
                }
                else if (Domain.Repsositories.CheckingForInputs.DoesEmailAlreadyExisist(registrationEmail))
                {
                    Console.WriteLine("Vec postoji racun s tim emailom");
                    var confirmForEmail = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                    if (confirmForEmail)
                    {
                        Console.Write("Unesite email za registraciju:");
                        registrationEmail = Console.ReadLine().Trim();
                    }
                    else
                    {
                        Console.WriteLine("Proces registracije je prekinut.");
                        Console.ReadKey();
                        return;
                    }

                }
                else
                {
                    break;
                }
            }

            Console.Write("Unesite iznos koji zelite da vam bude na racunu:");
            var inputForCurrentBalance = float.TryParse(Console.ReadLine(), out var registrationBalance);
            while (true)
            {
                if(registrationBalance >= 0 && inputForCurrentBalance)
                {
                    break;
                }
                else if(registrationBalance < 0)
                {
                    Console.WriteLine("Molimo vas unesite pozitivan iznos.");
                    var confirmForBalance = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                    if (confirmForBalance)
                    {
                        Console.Write("Unesite iznos koji zelite da vam bude na racunu:");
                        inputForCurrentBalance = float.TryParse(Console.ReadLine(), out registrationBalance);
                    }
                    else
                    {
                        Console.WriteLine("Proces registracije je prekinut.");
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
                        Console.Write("Unesite iznos koji zelite da vam bude na racunu:");
                        inputForCurrentBalance = float.TryParse(Console.ReadLine(), out registrationBalance);
                    }
                    else
                    {
                        Console.WriteLine("Proces registracije je prekinut.");
                        Console.ReadKey();
                        return;
                    }
                }

                
            }
            Console.WriteLine($"Registracija uspjesno napravljena.\nKreiran kupac:{registrationName}   {registrationEmail}   {registrationBalance}");
            Console.ReadKey();

            Domain.Repsositories.BuyerRepository.AddBuyer(registrationName, registrationEmail, registrationBalance);
        }

        public static void SignInSeller()
        {
            Console.Clear();
            Console.Write("Unesite ime za registraciju:");
            var registrationName = Console.ReadLine().Trim();
            while (string.IsNullOrEmpty(registrationName))
            {
                Console.WriteLine("Ime nemoze biti prazno.");
                var confirmForName = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                if (confirmForName)
                {
                    Console.Write("Unesite ime za registraciju:");
                    registrationName = Console.ReadLine().Trim();
                }
                else
                {
                    Console.WriteLine("Proces registriranja je prekinut.");
                    Console.ReadKey();
                    return;
                }

            }

            Console.Write("Unesite email za registraciju:");
            var registrationEmail = Console.ReadLine().Trim();
            while (true)
            {
                if (string.IsNullOrEmpty(registrationEmail))
                {
                    Console.WriteLine("Email nemoze biti prazan.");
                    var confirmForEmail = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                    if (confirmForEmail)
                    {
                        Console.Write("Unesite email:");
                        registrationEmail = Console.ReadLine().Trim();
                    }
                    else
                    {
                        Console.WriteLine("Proces registracije je prekinut.");
                        Console.ReadKey();
                        return;
                    }
                }
                else if (!Helper.ChecksIfInputIsValid.IsValid(registrationEmail))
                {
                    Console.WriteLine("Neipsravan format email-a.");
                    var confirmForEmail = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                    if (confirmForEmail)
                    {
                        Console.Write("Unesite email:");
                        registrationEmail = Console.ReadLine().Trim();
                    }
                    else
                    {
                        Console.WriteLine("Proces registracije je prekinut.");
                        Console.ReadKey();
                        return;
                    }
                }
                else if (Domain.Repsositories.CheckingForInputs.DoesEmailAlreadyExisist(registrationEmail))
                {
                    Console.WriteLine("Vec postoji racun s tim emailom");
                    var confirmForEmail = Helper.ChecksIfInputIsValid.ConfirmAndDelete();
                    if (confirmForEmail)
                    {
                        Console.Write("Unesite email za registraciju:");
                        registrationEmail = Console.ReadLine().Trim();
                    }
                    else
                    {
                        Console.WriteLine("Proces registracije je prekinut.");
                        Console.ReadKey();
                        return;
                    }

                }
                else
                {
                    break;
                }
            }

            Console.WriteLine($"Registracija uspjesno napravljena.\nKreiran prodavac:{registrationName}   {registrationEmail}");
            Console.ReadKey();

            Domain.Repsositories.SellerRepositories.AddSeller(registrationName, registrationEmail);

        }

    }
}
