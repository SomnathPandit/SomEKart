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
        public string CustAddress1 { get; set; }
        public string CustAddress2 { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double TotalAmount { get; set; }
        public bool IsPaid { get; set; }
    }
}
