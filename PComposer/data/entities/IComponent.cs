using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Enums;

namespace Data.Entities
{
    interface IComponent
    {
        ComponentType GetComponentType();
        Manufacturer GetManufacturer();
        int GetPrice();
        string ToRow();
    }
}
