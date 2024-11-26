using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using marketplace.Data.Models;
using marketplace.Data.Models.Users;
using marketplace.Data.Seed;

namespace marketplace.Domain.Repsositories
{
    public class SellerRepositories
    {
        public static void AddSeller(string sellerName,string sellerEmail)
        {
            seller seller = new seller(sellerName, sellerEmail);
            Seed.Sellers.Add(seller);
        }
    }
}
