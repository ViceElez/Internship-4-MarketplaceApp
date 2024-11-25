using marketplace.Data.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marketplace.Data.Models.Users
{
    public class buyer:User
    {
        public float currentBalance { get; set; }
        public List<Items.Items> ItemsBought { get; set; }
        public List<Items.Items> FavouriteItems { get; set; }

       public buyer(string name, string email,float balance): base(name, email)
        {
            currentBalance = balance;
            ItemsBought = new List<Items.Items>();
            FavouriteItems = new List<Items.Items>();
        }
        public buyer():base()
        {
            Console.Write("Upisite iznos koji zelite da vam bude na racunu:");
            var inputForCurrentBalance = float.TryParse(Console.ReadLine(),out var balance);
            while (true)
            {
                if (inputForCurrentBalance && balance>=0 )
                {
                    currentBalance = balance;
                    break;
                }
                else if (balance < 0)
                {
                    Console.WriteLine("Molimo vas unesite pozitivan iznos.");
                    var confirmForBalance = ConfirmAndDelete();
                    if (confirmForBalance)
                    {
                        Console.Write("Upisite iznos koji zelite da vam bude na racunu:");
                        inputForCurrentBalance = float.TryParse(Console.ReadLine(), out balance);
                    }
                    else
                    {
                        Console.WriteLine("Proces kreiranja je zavrsio.");
                        Console.ReadKey();
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Molimo vas unesite brojcanu vrijednost.");
                    var confirmForBalance = ConfirmAndDelete();
                    if (confirmForBalance)
                    {
                        Console.Write("Upisite iznos koji zelite da vam bude na racunu:");
                        inputForCurrentBalance = float.TryParse(Console.ReadLine(), out balance);
                    }
                    else
                    {
                        Console.WriteLine("Proces kreiranja je zavrsio.");
                        Console.ReadKey();
                        return;
                    }
                }
            }
            ItemsBought = new List<Items.Items>();
            FavouriteItems = new List<Items.Items>();
        }
    }
}
