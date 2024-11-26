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
        public static string FindingBuyerByEmail(string buyerEmail)
        {
            var foundBuyer = false;
            foreach (buyer buyer in Seed.Buyers)
            {
                if (buyer.Email == buyerEmail)
                {
                    foundBuyer = true;
                    return buyer.Name;
                }
            }
            if (!foundBuyer)
            {
                return null;
            }
            else
            {
                return null;
            }
        }
        public static void AddBuyer(string buyerName, string buyerEmail, float buyerBalance)
        {
            buyer newBuyer = new buyer(buyerName, buyerEmail, buyerBalance);
            Seed.Buyers.Add(newBuyer);
        }
    }
}
