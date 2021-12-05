using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Domain.Entities;

namespace Presentation.Entities
{
    public class PreviousOrders
    {
        public static void View()
        {
            if (OrderActions.Count() == 0)
            {
                Console.WriteLine("Kupite neko racunalo pa ova lista nece biti prazna");
                return;
            }

            PrintPreviousOrders();

            Receipt.Print(GetOrderFromInput());
        }

        public static void PrintPreviousOrders()
        {
            foreach(var order in OrderActions.Get().Select((value, i) => new { i, value }))
            {
                Console.WriteLine($"{order.i + 1} - Order created at {order.value.CreatedAt}");
            }
        }

        public static Order GetOrderFromInput()
        {
            var orderInput = Helpers.GetUserInput(OrderActions.Count(), "Odaberite narudzbu: ");
            return OrderActions.Get()[orderInput - 1];
        }

    }
}
