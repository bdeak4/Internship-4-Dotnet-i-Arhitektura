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
