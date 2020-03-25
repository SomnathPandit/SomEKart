using SomEKart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomEKart.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public double TotalAmount
        {
            get
            {
                return ShoppingCartItems.Sum(a => a.Amount);
            }
        }
        public double TotalQuantity
        {
            get
            {
                return ShoppingCartItems.Sum(a => a.Quantity);
            }
        }
    }
}
