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
        public static decimal CalculatePrice(Computer computer)
        {   
            var components = computer.Components.Aggregate(0, (acc, x) => acc + x.GetPrice());
            var assembling = computer.Components.Length * 25;
            var delivery = DeliveryActions.CalculateDelivery(computer);
            return components + assembling + delivery;
        }
    }
}
