using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marketplace.Data.Models.Coupons
{
    public class Coupons
    {
        public Guid Code { get; set; }
        public string Category { get; set; }
        public double Discount { get; set; }
        public DateTime ExpirationDate { get; set; }

        public Coupons(string category, double discount, DateTime expirationDate)
        {
            Code = Guid.NewGuid();
            Category = category;
            Discount = discount;
            ExpirationDate = expirationDate;
        }

    }
}
