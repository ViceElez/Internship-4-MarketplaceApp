using marketplace.Data.Models;
using marketplace.Data.Models.Users;
using marketplace.Data.Seed;    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marketplace.Domain.Repsositories
{
    public class BuyerRepository
    {
        public static void AddBuyer(string buyerName, string buyerEmail, float buyerBalance)
        {
            buyer buyer = new buyer(buyerName, buyerEmail, buyerBalance);
            Seed.Buyers.Add(buyer);
        }
    }
}
