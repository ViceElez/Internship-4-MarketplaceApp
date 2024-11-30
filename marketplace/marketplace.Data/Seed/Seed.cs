using marketplace.Data.Models.Coupons;
using marketplace.Data.Models.Items;
using marketplace.Data.Models.Users;
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
        public static readonly List<Models.Items.Items> Items = new List<Models.Items.Items>()
        {
            new Items("Laptop", "High-end gaming laptop", 1500.0, "Elektronika", Sellers[0]),
             new Items("Mobitel", "Latest model smartphone", 800.0, "Elektronika",Sellers[3] ),
            new Items("Stolica", "Ergonomic office chair", 120.0, "Namjestaj", Sellers[2]),
            new Items("Masina za robu", "", 200.0, "Aparati", Sellers[1]),
            new Items("Jaketa", "", 100.0, "Odjeca",Sellers[0] ),
            new Items("Jabuka", "",5.0,"Namirnice",Sellers[1])
        };


        public static readonly List<Models.Transactions.Transactions> Transactions = new List<Models.Transactions.Transactions>();

        public static readonly List<Models.Coupons.Coupons> Coupons = new List<Models.Coupons.Coupons>()
        {
            new Coupons("Elektronika", 10.0, new DateTime(2025, 12, 31)), 
            new Coupons("Namjestaj", 15.0, new DateTime(2025, 11, 30)),   
            new Coupons("Aparati", 20.0, new DateTime(2025, 1, 15)),      
            new Coupons("Namirnice", 5.0, new DateTime(2025, 12, 25)),    
            new Coupons("Odjeca", 25.0, new DateTime(2025, 11, 30)),
            new Coupons("Igracke", 10.0, new DateTime(2025, 6, 30)),
            new Coupons("Knjige", 20.0, new DateTime(2025, 9, 15)),
            new Coupons("Sport", 12.5, new DateTime(2025, 8, 20)),
            new Coupons("Kozmetika", 18.0, new DateTime(2025, 7, 5)),
            new Coupons("Auto dijelovi", 8.0, new DateTime(2025, 10, 10)),
            new Coupons("Tehnologija", 30.0, new DateTime(2025, 12, 1)),
            new Coupons("Kucni ljubimci", 5.0, new DateTime(2025, 3, 1)),
            new Coupons("Zdravlje", 15.0, new DateTime(2025, 5, 15)),
            new Coupons("Putovanja", 25.0, new DateTime(2025, 11, 20)),
            new Coupons("Alati", 10.0, new DateTime(2025, 4, 10)),
            new Coupons("Nakiti", 22.0, new DateTime(2025, 12, 10)),
            new Coupons("Usluge", 7.5, new DateTime(2025, 2, 28)),
        };



    }
}
