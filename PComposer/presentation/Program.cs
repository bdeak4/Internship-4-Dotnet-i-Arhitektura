using System;
using domain.entities;

namespace presentation
{
    class Program
    {
        enum Menu
        {
            Main,
            OrderPC,
            PreviousOrders,
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Dobro dosli, molimo unesite osobne podatke");

            Console.Write("Ime: ");
            var name = Console.ReadLine();

            Console.Write("Prezime: ");
            var surname = Console.ReadLine();

            Console.Write("Adresa: ");
            var address = Console.ReadLine();

            User.Set(name, surname, address);

            var menu = 0;
            var exit = false;
            while (!exit)
            {
                Console.Clear();
                switch ((Menu)menu)
                {
                    case Menu.Main:
                        menu = Choice(new string[] {
                            "Sastavi i naruči novo računalo",
                            "Prikaži moje narudžbe",
                        }, menu);

                        if (menu == 0)
                        {
                            exit = true;
                            Console.WriteLine("Izlaz iz aplikacije");
                        }
                        break;

                    case Menu.OrderPC:
                        menu = Choice(new string[] { }, menu);
                        break;

                    case Menu.PreviousOrders:
                        menu = Choice(new string[] { }, menu);
                        break;
                }
            }
        }
         

        static int Choice(string[] actions, int prev_choice)
        {
            if (actions.Length == 0)
            {
                Console.WriteLine("Pritisnite bilo koju tipku za povratak u glavni izbornik");
                Console.ReadKey();
                return (int)Menu.Main;
            }

            Console.WriteLine("Akcije:");
            for (var i = 0; i < actions.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {actions[i]}");
            }

            if (prev_choice == 0)
            {
                Console.WriteLine("0 - Odjavi se");
            }
            else
            {
                Console.WriteLine("0 - Povratak u glavni izbornik");
            }

            Console.Write("Odaberite akciju: ");
            bool success = int.TryParse(Console.ReadLine(), out int choice);
            while (choice < 0 || choice > actions.Length || !success)
            {
                Console.WriteLine("Odabir mora biti jedan od brojeva u listi.");
                Console.Write("Odaberite akciju: ");
                success = int.TryParse(Console.ReadLine(), out choice);
            }

            if (prev_choice > 0 && choice != 0)
            {
                choice += prev_choice * 10;
            }

            return choice;
        }
    }
}
