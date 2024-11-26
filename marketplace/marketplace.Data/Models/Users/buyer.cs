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
        
    }
}
