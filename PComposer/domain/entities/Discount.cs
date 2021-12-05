using Data.Entities;
using Data.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class DiscountActions
    {
        public static DiscountType[] GetAvailableDiscountTypes(Computer[] computers)
        {
            var discounts = new List<DiscountType> { };

            if (OrderStore.SpentSinceMembershipDiscount > 1000)
                discounts.Add(DiscountType.MembershipDiscount);

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
