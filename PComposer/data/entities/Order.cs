using System;

namespace Data.Entities
{
    public class Order
    {
        public Computer[] Computers;
        public Discount Discount;
        public DateTime CreatedAt = DateTime.Now;
    }
}
