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
            new Models.Users.buyer("Marko", "marko@primjer.hr", 500.00f),
            new Models.Users.buyer("Lucija", "lucija@primjer.com", 300.00f),
            new Models.Users.buyer("Petra", "petra@primjer.hr", 1000.00f),
            new Models.Users.buyer("Ivan", "ivan@primjer.com", 250.00f),
            new Models.Users.buyer("Ana", "ana@primjer.hr", 750.00f)
        };

       public static readonly List<Models.Users.seller> Sellers = new List<Models.Users.seller> { 
            new Models.Users.seller("Klara", "klara@prodaja.hr", 1000.00f),
            new Models.Users.seller("Tomislav", "tomislav@prodaja.com", 2500.00f),
            new Models.Users.seller("Jelena", "jelena@prodaja.hr", 1500.00f),
            new Models.Users.seller("Marko", "marko@prodaja.com", 2000.00f)
        };

        public static readonly List<Models.Items.Items> Items = new List<Models.Items.Items> {
            new Models.Items.Items("Laptop", "Visokokvalitetni laptop za rad i igru", 5000, "na prodaju", "Tehnika", Sellers[0], 4.5f),
            new Models.Items.Items("Telefon", "Pametan telefon sa svim funkcijama", 3000, "na prodaju", "Tehnika", Sellers[1], 4.2f),
            new Models.Items.Items("Stol", "Elegantni stol za dnevni boravak", 1500, "na prodaju", "Namještaj", Sellers[2], 4.8f),
            new Models.Items.Items("Knjiga", "Zanimljiv roman za ljubitelje misterije", 200, "na prodaju", "Knjige", Sellers[3], 4.0f),
            new Models.Items.Items("Slikarska oprema", "Komplet za slikare", 450, "na prodaju", "Umjetnost", Sellers[2], 4.7f)
        };

        public static readonly List<Models.Transactions.Transactions> Transactions = new List<Models.Transactions.Transactions> { 
             new Models.Transactions.Transactions(Sellers[0].ID, Buyers[0].ID, 5000.00f),
             new Models.Transactions.Transactions(Sellers[1].ID, Buyers[1].ID, 3000.00f),
             new Models.Transactions.Transactions(Sellers[2].ID, Buyers[2].ID, 1200.00f),
             new Models.Transactions.Transactions(Sellers[3].ID, Buyers[3].ID, 150.00f),
             new Models.Transactions.Transactions(Sellers[0].ID, Buyers[4].ID, 4000.00f)
            };


    }
}
