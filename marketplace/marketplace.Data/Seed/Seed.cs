using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace marketplace.Data.Seed
{
    public static class Seed
    {
        
        public static readonly List<Models.Users.buyer> Buyers = new List<Models.Users.buyer> { 
            new Models.Users.buyer("Marko", "marko@primjer.hr", 500.00d),
            new Models.Users.buyer("Lucija", "lucija@primjer.com", 300.00d),
            new Models.Users.buyer("Petra", "petra@primjer.hr", 1000.00d),
            new Models.Users.buyer("Ivan", "ivan@primjer.com", 250.00d),
            new Models.Users.buyer("Ana", "ana@primjer.hr", 750.00d)
        };

       public static readonly List<Models.Users.seller> Sellers = new List<Models.Users.seller> { 
            new Models.Users.seller("Klara", "klara@prodaja.hr", 1000.00d),
            new Models.Users.seller("Tomislav", "tomislav@prodaja.com", 2500.00d),
            new Models.Users.seller("Jelena", "jelena@prodaja.hr", 1500.00d),
            new Models.Users.seller("Marko", "marko@prodaja.com", 2000.00d)
        };

        public static readonly List<Models.Transactions.Transactions> Transactions = new List<Models.Transactions.Transactions>();



    }
}
