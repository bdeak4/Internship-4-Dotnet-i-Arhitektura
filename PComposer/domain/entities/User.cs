using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data.entities;

namespace domain.entities
{
    public class User
    {
        public static string Name { get => UserStorage.Name; }
        public static string Surname { get => UserStorage.Surname; }
        public static string Address { get => UserStorage.Address; }
        public static int Distance { get => UserStorage.Distance; }

        public static void Set(string name, string surname, string address)
        {
            UserStorage.Name = name;
            UserStorage.Surname = surname;
            UserStorage.Address = address;

            var r = new Random();
            UserStorage.Distance = r.Next(50, 999);
        }
    }
}
