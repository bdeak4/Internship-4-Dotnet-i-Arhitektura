using Data;
using Data.Entities;
using Data.Enums;
using System.Linq;

namespace Domain.Entities
{
    public class ComponentActions
    {
        static public Component[] GetByType(ComponentType componentType)
        {
            return Seed.Data.Where(c => c.GetComponentType() == componentType).ToArray();
        }
    }
}
