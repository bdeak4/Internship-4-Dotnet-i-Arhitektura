using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Enums;
using Data.Entities;

namespace Domain.Entities
{
    public class DiscountActions
    {
        public static DiscountType[] GetAvailableDiscountTypes(Computer[] computers)
        {
            var discounts = new List<DiscountType> { };

            // TODO: check orders

            var len = GetFreeComponents(computers).Count;
            if (len > 0)
                discounts.Add(DiscountType.QuantityDiscount);

            discounts.Add(DiscountType.CouponDiscount);

            return discounts.ToArray();
        }

        public static List<Component> GetFreeComponents(Computer[] computers)
        {
            return computers
                        .SelectMany(x => x.Components)
                        .GroupBy(x => x)
                        .Where(x => x.Count() > 1)
                        .Select(x => x.Key)
                        .ToList();
        }
    }
}
