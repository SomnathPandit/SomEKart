using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomEKart.Models
{
    public class Payment: BaseModel
    {
        public int BillingId { get; set; }
        public double AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentModes PaymentMode { get; set; }
    }

    public enum PaymentModes
    {
        Cash,
        Card,
        NetBank,
        Paypal,
        Upi
    }
}
