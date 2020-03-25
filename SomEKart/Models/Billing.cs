using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomEKart.Models
{
    public class Billing: BaseModel
    {
        public int OrderId { get; set; }
        public string CustName { get; set; }
        public string CustAddress { get; set; }
        public string Phone { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double TotalAmount { get; set; }
    }
}
