using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    class Case : Component, IComponent
    {
        public CaseMaterial Material;
        public decimal WeightInKg;
        public Case()
        {

        }

        public ComponentType GetComponentType() => ComponentType.Case;
    }
}
