using SomEKart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomEKart.ViewModels
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public Billing BillingDetails { get; set; }
    }
}
