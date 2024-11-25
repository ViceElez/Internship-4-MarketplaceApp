using marketplace.Data.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marketplace.Data.Models.Transactions
{
    public class Transactions
    {
        public Guid IdOfTransaction { get; set; }
        public Guid TransactionSellerID { get; set; }
        public Guid TransactionBuyerID { get; set; }
        public DateTime DateOfTransaction { get; set; }
        public float Amount { get; set; }

        public Transactions(Guid sellerID, Guid buyerID, float amount)
        {
            IdOfTransaction = Guid.NewGuid();
            TransactionSellerID = sellerID;
            TransactionBuyerID = buyerID;
            DateOfTransaction = DateTime.Now;
            Amount = amount;
        }
    }
}
