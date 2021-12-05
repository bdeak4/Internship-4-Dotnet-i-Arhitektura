using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    class Case : Component, IComponent, IHasWeight
    {
        public CaseMaterial Material;
        public decimal WeightInKg;
        public Case()
        {

        }

        override public ComponentType GetComponentType() => ComponentType.Case;

        override public string ToRow()
        {
            var name = $"{Manufacturer} {Material} case ({WeightInKg}kg)";
            return $"{name,-40} | {Price}";
        }

        public decimal GetWeightInKg() => WeightInKg;
    }
}
