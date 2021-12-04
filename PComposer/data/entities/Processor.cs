using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    class Processor : Component, IComponent
    {
        public int NumOfCores;

        public Processor()
        {

        }

        override public ComponentType GetComponentType() => ComponentType.Processor;

        override public string ToRow()
        {
            var name = $"{Manufacturer} {NumOfCores} core processor";
            return $"{name,-40} | {Price}";
        }
    }
}
