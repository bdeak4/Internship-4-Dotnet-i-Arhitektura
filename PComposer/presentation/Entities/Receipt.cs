using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Enums;
using Domain.Entities;

namespace Presentation.Entities
{
    public class Receipt
    {
        public static void Print (Order order)
        {
            Console.Clear();

            PrintHeader();

            foreach(var pc in order.Computers.Select((value, i) => new { i, value }))
                PrintPC(pc.value, pc.i + 1);

            PrintDiscount(order);

            PrintTotal(order);
        }

        public static void PrintHeader()
        {
            Console.WriteLine("Racun za narudzbu");
            Console.WriteLine("".PadRight(80, '-'));
        }

        public static void PrintPC(Computer pc, int index)
        {
            var name = $"Konfiguracija {index}";
            var total = ComputerActions.CalculatePrice(pc);

            Console.Write($"{name,-60} | ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{total}kn");
            Console.ResetColor();

            foreach (var component in pc.Components)
                PrintIndentedItem(component.GetName(), component.GetPrice());

            PrintIndentedItem("Usluga sastavljanja", pc.Components.Length * 25);
            PrintIndentedItem("Dostava", DeliveryActions.CalculateDelivery(pc));
        }

        public static void PrintIndentedItem(string name, decimal price)
        {
            Console.WriteLine($"    {name,-56} | {price}kn");
        }

        public static void PrintDiscount(Order order)
        {
            if (order.Discount == null)
                return;

            if (order.Discount.freeComponents != null)
            {
                Console.WriteLine($"{"Besplatne komponente (2 + 1 gratis)",-60} |");

                foreach (var component in order.Discount.freeComponents)
                    PrintIndentedItem(component.GetName(), 0);
            }

            if (order.Discount.amountDiscount != null)
            {
                Console.WriteLine($"{"Popust za vjerno clanstvo",-60} | -{order.Discount.amountDiscount}kn");
            }

            if (order.Discount.percentDiscount != null)
            {
                Console.WriteLine($"{"Promotivni kod",-60} | -{order.Discount.percentDiscount}%");
            }
        }

        public static void PrintTotal(Order order)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{"ukupno",-60} | {OrderActions.CalculateTotal(order)}kn");
            Console.ResetColor();
        }
    }
}
