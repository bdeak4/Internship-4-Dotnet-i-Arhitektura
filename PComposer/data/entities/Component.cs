using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Component
    {
        public int Price;
        public Manufacturer Manufacturer;

        public Manufacturer GetManufacturer() => Manufacturer;
        public int GetPrice() => Price;

        virtual public ComponentType GetComponentType()
        {
            throw new NotImplementedException();
        }

        public string ToRow()
        {
            return $"{GetName(),-40} | {Price}";
        }

        virtual public string GetName()
        {
            throw new NotImplementedException();
        }
    }
}
