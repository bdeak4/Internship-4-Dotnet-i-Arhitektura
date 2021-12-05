using System;
using Domain.Entities;
using Presentation.Enums;

namespace Presentation
{
    class Program
    {
        public static Menu CurrentMenu = Menu.Main;

        static void Main(string[] args)
        {
            AskForUserInfo();
            ShowMenu();
        }

        static void AskForUserInfo()
        {
            Console.WriteLine("Dobro dosli, molimo unesite osobne podatke");

            Console.Write("Ime: ");
            var name = Console.ReadLine();

            Console.Write("Prezime: ");
            var surname = Console.ReadLine();

            Console.Write("Adresa: ");
            var address = Console.ReadLine();

            User.Set(name, surname, address);
        }

        static void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                
                switch (CurrentMenu)
                {
                    case Menu.Main:
                        break;

                    case Menu.OrderPC:
                        OrderMenu.Order();
                        break;

                    case Menu.Exit:
                        return;
                }

                CurrentMenu = Helpers.GetMenuChoice();
            }
        }
    }
}
