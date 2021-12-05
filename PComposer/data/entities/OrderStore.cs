using System.Collections.Generic;

namespace Data.Entities
{
    public class OrderStore
    {
        static public List<Order> Orders = new() { };
        static public decimal SpentSinceMembershipDiscount = 0;
    }
}
