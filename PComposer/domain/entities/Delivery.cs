using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DeliveryActions
    {
        static public decimal CalculateHomeDelivery(Component[] components)
        {
            var weight = CalculateComponentWeight(components);

            if (weight < 3)
                return (5.0M / 10) * User.Distance; // motor

            if (weight > 10)
                return 50 + (10.0M / 20) * User.Distance; // kamion

            return (3.0M / 5) * User.Distance; // auto
        }

        static public decimal CalculateComponentWeight(Component[] components)
        {
            var totalWeight = 0.0M;

            foreach (var component in components)
            {
                if (component is IHasWeight)
                {
                    totalWeight += ((IHasWeight)component).GetWeightInKg();
                }
            }

            return totalWeight;
        }
    }
}
