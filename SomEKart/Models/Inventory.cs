using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomEKart.Models
{
    public class Inventory : BaseModel
    {
        public int ItemId { get; set; }
        public bool IsAvilable { get; set; }
    }
}
