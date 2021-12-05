using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Enums;
using Data.Entities;
using Domain.Entities;

namespace Presentation
{
    class OrderMenu
    {
        static public void Order()
        {
            while (true)
            {
                var components = ChooseComponents.Choose();

                PrintDeliveryOptions(components);
                var delivery = GetDeliveryFromUserInput();

                PrintContinueOrBuildAnother();
                if (Helpers.GetUserInput(2, "Odaberite akciju: ") == 1)
                    return;
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
    }
}
