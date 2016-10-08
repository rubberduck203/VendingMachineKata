using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending.Core
{
    public class PriceState : VendingMachineState
    {
        public override string Display()
        {
            return "PRICE: $1.00";
        }
    }
}
