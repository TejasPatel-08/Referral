﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Referral.Models
{
    public class CustomersPointsVM
    {
        public Guid CustomerId { get; set; }      
        public decimal PurchasePoints { get; set; }
        public decimal ReferralPoints { get; set; }
        public decimal RedeemPoint { get; set; }       
        public decimal TotalPoints { get; set; }
    }
}
