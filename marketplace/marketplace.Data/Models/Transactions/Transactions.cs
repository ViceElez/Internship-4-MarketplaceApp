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
        public Guid IdOfItem { get; set; }
        public Guid TransactionSellerID { get; set; }
        public Guid TransactionBuyerID { get; set; }
        public DateTime DateOfTransaction { get; set; }
        public double Amount { get; set; }

        public Transactions(Guid idOfItem, Guid sellerID, Guid buyerID, DateTime dateOfTransaction, double amount)
        {
            IdOfItem = idOfItem;
            TransactionSellerID = sellerID;
            TransactionBuyerID = buyerID;
            DateOfTransaction = dateOfTransaction;
            Amount = amount;
        }
    }
}
