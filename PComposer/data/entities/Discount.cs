using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Discount
    {
        public Component[] freeComponents;
        public int? percentDiscount;
        public int? amountDiscount;
    }
}
