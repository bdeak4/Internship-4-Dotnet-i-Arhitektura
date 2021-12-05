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
            OrderStore.SpentSinceMembershipDiscount += CalculateTotal(order);
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

        public static void ResetMembershipDiscount()
        {
            OrderStore.SpentSinceMembershipDiscount = 0;
        }

        public static decimal CalculateTotal(Order order)
        {
            var total = 0M;

            foreach (var pc in order.Computers)
                total += ComputerActions.CalculatePrice(pc);

            if (order.Discount != null && order.Discount.percentDiscount != null)
                total -= (total * ((int)(order.Discount.percentDiscount) / 100M));

            if (order.Discount != null && order.Discount.amountDiscount != null)
                total -= (int)(order.Discount.amountDiscount);

            return total;
        }
    }
}
