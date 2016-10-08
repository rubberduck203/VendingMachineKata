using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending.Core
{
    public class PriceState : VendingMachineState
    {
        private readonly decimal _priceInCents;

        public PriceState(int priceInCents)
        {
            _priceInCents = priceInCents;
        }

        public override string Display()
        {
            return $"PRICE: {_priceInCents/100:C}";
        }
    }
}
