﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Data.Entities.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Buyer Buyer { get; set; }
        public Merchant Merchant { get; set; }
        public DateTime TimeOfPurchase { get; set; }
    }
}
