using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ComputerActions
    {
        public static int CalculatePrice(Computer computer)
        {
            return computer.Components.Aggregate(0, (acc, x) => acc + x.GetPrice());
        }
    }
}
