using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marketplace.Data.Models.Users
{
    public class seller:User
    {
        public double currentProfit { get; set; }
        public List<Items.Items> Products { get; set; }

        public seller(string name, string email, double profit) : base(name, email)
        {
            currentProfit = profit;
            Products = new List<Items.Items>();
        }

        public seller(string name, string email):base(name,email)
        {

            currentProfit = 0.00d;
            Products = new List<Items.Items>();
        }
    }
}
