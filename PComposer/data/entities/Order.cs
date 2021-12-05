using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Order
    {
        public Computer[] Computers;
        public Discount Discount;
        public DateTime CreatedAt = DateTime.Now;
    }
}
