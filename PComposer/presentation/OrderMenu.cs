using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Enums;
using Data.Entities;
using Domain.Entities;
using Data.Enums;

namespace Presentation
{
    class OrderMenu
    {
        static public Order Order()
        {
            var computers = OrderChooseComponentsAndDelivery();
            var discount = OrderChooseDiscount(computers);
            return new Order { Computers = computers, Discount = discount };
        }

        private static Dictionary<DiscountType, string> DiscountRows = new()
        {
            {DiscountType.MembershipDiscount, "Kupon popust za vjerno članstvo" },
            {DiscountType.QuantityDiscount, "Popust na količinu" },
            {DiscountType.CouponDiscount, "Popust unosom koda" }
        };

        static public Discount OrderChooseDiscount(Computer[] computers)
        {
            var discounts = DiscountActions.GetAvailableDiscountTypes(computers);

            while (true)
            {
                PrintAvailableDiscountTypes(discounts);

                var discountInput = Helpers.GetUserInput(discounts.Length + 1, "Odaberite popust: ");

                if (discountInput == 1)
                    return null;

                var discount = HandleDiscount(discounts[discountInput - 2], computers);

                if (discount != null)
                    return discount;
            }
        }

        static public Discount HandleDiscount(DiscountType discountType, Computer[] computers)
        {
            switch (discountType)
            {
                case DiscountType.MembershipDiscount:
                    // TODO
                    break;

                case DiscountType.QuantityDiscount:
                    var components = DiscountActions.GetFreeComponents(computers).ToArray();

                    Console.WriteLine("Zbog popusta na kolicinu ove proizvode dobijate besplatno:");

                    ChooseComponents.PrintComponentTable(components);

                    return new Discount { freeComponents = components };

                case DiscountType.CouponDiscount:
                    // TODO
                    break;
            }
            return null;
        }

        static public void PrintAvailableDiscountTypes(DiscountType[] discounts)
        {
            Console.Clear();
            Console.WriteLine("Odaberite popust:");
            Console.WriteLine("1 - ne zelim popust");

            foreach (var discount in discounts.Select((value, i) => new { i, value }))
            {
                Console.WriteLine($"{discount.i + 2} - {DiscountRows[discount.value]}");
            }
        }

        static public Computer[] OrderChooseComponentsAndDelivery()
        {
            var computers = new List<Computer> { };
            while (true)
            {
                var components = ChooseComponents.Choose();

                PrintDeliveryOptions(components);
                var delivery = GetDeliveryFromUserInput();

                var computer = new Computer { Components = components, Delivery = delivery };
                computers.Add(computer);

                PrintContinueOrBuildAnother();
                if (Helpers.GetUserInput(2, "Odaberite akciju: ") == 1)
                    return computers.ToArray();
            } 
        }

        static public void PrintDeliveryOptions(Component[] components)
        {
            Console.Clear();
            Console.WriteLine("Načini preuzimanja paketa:");
            Console.WriteLine("1 - Osobno preuzimanje (besplatno)");
            Console.WriteLine($"2 - Dostava na unesenu adresu ({DeliveryActions.CalculateHomeDelivery(components)}kn)");
        }


        static public Delivery GetDeliveryFromUserInput()
        {
            var max = Enum.GetNames(typeof(Delivery)).Length;
            var deliveryInput = Helpers.GetUserInput(max, "Odaberite nacin dostave: ");
            return (Delivery)(deliveryInput - 1);
        }

        static public void PrintContinueOrBuildAnother()
        {
            Console.Clear();
            Console.WriteLine("Akcije:");
            Console.WriteLine("1 - Nastavak kupnje");
            Console.WriteLine("2 - Sastavi jos jedan PC");
        }

        static public bool ConfirmOrder()
        {
            Console.Clear();
            Console.WriteLine("Akcije: ");
            Console.WriteLine("1 - Potvrdi narudzbu");
            Console.WriteLine("2 - Odustani od narudzbe");

            return Helpers.GetUserInput(2, "Odaberite akciju: ") == 1;
        }

    }
}
