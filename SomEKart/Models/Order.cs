using System;
using System.Collections.Generic;

namespace SomEKart.Models
{
    public class OrderItem : BaseModel
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public bool IsDelivered { get; set; }
    }

    public class Order : BaseModel
    {
        public List<OrderItem> OrderItems { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderAcceptedBy { get; set; }
    }

}