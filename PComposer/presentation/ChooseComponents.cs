using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Data.Entities;
using Data.Enums;

namespace Presentation
{
    class ChooseComponents
    {
        public static Component[] Choose()
        {
            var components = new List<Component> { };
            var componentTypes = Enum.GetValues(typeof(ComponentType)).Cast<ComponentType>();

            foreach (var componentType in componentTypes)
            {
                var component = ChooseComponent(componentType);

                if (component != null)
                    components.Add(component);
            }

            return components.ToArray();
        }

        public static Component ChooseComponent(ComponentType componentType)
        {
            var components = ComponentActions.GetByType(componentType);

            Console.Clear();
            Console.WriteLine($"Odaberite komponentu {componentType}:");

            PrintComponentTable(components);

            var id = Helpers.GetUserInput(components.Length, "Odaberite proizvod (id): ");

            if (id == 0)
                return null;

            return components[id - 1];
        }

        public static void PrintComponentTable(Component[] components)
        {
            Console.WriteLine($" id | {"naziv",-40} | cijena");
            Console.WriteLine(" -- | ---------------------------------------- | ------");
            
            foreach (var component in components.Select((value, i) => new { i, value }))
            {
                Console.WriteLine($"{(component.i + 1),3} | {component.value.ToRow()}");
            }
        }

    }
}
