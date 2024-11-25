using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marketplace.Data.Seed
{
    public static class Program
    {
        public class Context
        {
            public List<Models.Users.buyer> Buyers { get; set; }=Seed.Buyers;
            public List<Models.Users.seller> Sellers { get; set; }= Seed.Sellers;
            public List<Models.Items.Items> Items { get; set; } = Seed.Items;
            public List<Models.Transactions.Transactions> Transactions { get; set; }=Seed.Transactions;
        }
    }
}
