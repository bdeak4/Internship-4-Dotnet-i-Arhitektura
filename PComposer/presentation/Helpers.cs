using Presentation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class Helpers
    {
        private static string[] MainMenuOptions =
        {
            "Sastavi i naruči novo računalo",
            "Prikaži moje narudžbe"
        };

        public static Dictionary<Menu, string[]> MenuOptions = new Dictionary<Menu, string[]>
        {
            { Menu.Main, MainMenuOptions },
        };

        public static Menu GetMenuChoice(Menu currentMenu)
        {
            if (!MenuOptions.ContainsKey(currentMenu))
            {
                Console.WriteLine("Pritisnite bilo koju tipku za povratak u glavni izbornik");
                Console.ReadKey();
                return Menu.Main;
            }

            PrintMenuOptions(currentMenu);
            return GetUserInput(currentMenu);
        }

        private static void PrintMenuOptions(Menu currentMenu)
        {
            Console.WriteLine("Akcije:");
            foreach (var item in MenuOptions[currentMenu].Select((value, i) => new { i, value }))
            {
                Console.WriteLine($"{item.i + 1} - {item.value}");
            }

            if (currentMenu == Menu.Main)
            {
                Console.WriteLine("0 - Odjavi se");
            }
            else
            {
                Console.WriteLine("0 - Povratak u glavni izbornik");
            }
        }
        private static Menu GetUserInput(Menu currentMenu)
        {
            while (true)
            {
                Console.Write("Odaberite akciju: ");
                bool success = Menu.TryParse(Console.ReadLine(), out Menu choice);

                if (currentMenu == Menu.Main && choice == Menu.Main)
                {
                    return Menu.Exit;
                }

                if (success && choice >= Menu.Main && (int)choice <= MenuOptions[currentMenu].Length)
                {
                    // bez ovog podmeniji nebi mogli raditi
                    // npr. ako smo u meniju 5 i odaberemo opciju 1
                    //      ovo ce pretvoriti choice u 51
                    if (currentMenu > Menu.Main && choice != Menu.Main)
                    {
                        choice += (int)currentMenu * 10;
                    }

                    return choice;
                }

                Console.WriteLine("Odabir mora biti jedan od brojeva u listi.");
            }
        }
    }
}
