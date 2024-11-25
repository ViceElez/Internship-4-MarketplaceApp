using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marketplace.Data.Models.Users
{
    public class seller:User
    {
        public float currentProfit { get; set; }
        public List<Items.Items> Products { get; set; }

        public seller(string name, string email, float profit) : base(name, email)
        {
            currentProfit = profit;
            Products = new List<Items.Items>();
        }

        public seller()
        {
            currentProfit = 0;
            Products = new List<Items.Items>();
        }
    }
}
