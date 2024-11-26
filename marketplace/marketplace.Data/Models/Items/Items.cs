﻿using marketplace.Data.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marketplace.Data.Models.Items
{
    public class Items
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public seller SellerOfItem { get; set; }
        public float Rating { get; set; }

        public Items(string name,string description,float price, string category, seller seller)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            Status = "na prodaju";
            Category = category;
            SellerOfItem = seller;
            Rating = 0.00f;
        }

        public Items(string name, string description, float price, string status, string category, seller sellerOfItem, float rating)
        {
            Id =Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            Status = status;
            Category = category;
            SellerOfItem = sellerOfItem;
            Rating = rating;
        }
    }
}
