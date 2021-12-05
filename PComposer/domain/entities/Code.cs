using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;


namespace Domain.Entities
{
    public class Code
    {
        public static bool Check(string code)
        {
            return Seed.Codes.ContainsKey(code);
        }

        public static int GetDiscount(string code)
        {
            if (!Check(code))
                return 0;

            
            var discount = Seed.Codes[code];

            Seed.Codes.Remove(code);

            return discount;
        }
    }
}
