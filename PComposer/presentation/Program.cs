using System;
using domain.entities;

namespace presentation
{
    class Program
    {
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
            Console.WriteLine(User.Distance);
        }
    }
}
