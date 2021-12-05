using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderActions
    {
        public static void Add(Order order)
        {
            OrderStore.Orders.Add(order);
        }

        public static int Count()
        {
            return OrderStore.Orders.Count();
        }

        public static Order[] Get()
        {
            return OrderStore.Orders.ToArray();
        }
    }
}
