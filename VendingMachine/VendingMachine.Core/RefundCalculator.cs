using System.Collections.Generic;

namespace Vending.Core
{
    public class RefundCalculator
    {
        public IDictionary<Coin, int> CalculateRefund(int priceInCents, int paidInCents)
        {
            var refundValue = paidInCents - priceInCents;
            var nickels = refundValue / 5;

            var dimes = 0;
            if (nickels % 2 == 0)
            {
                dimes = nickels / 2;
                nickels = 0;
            }
            else if(nickels % 3 == 0)
            {
                dimes = 1;
                nickels = 1;
            }

            return new Dictionary<Coin, int>()
            {
                {Coin.Nickel, nickels},
                {Coin.Dime, dimes},
                {Coin.Quarter, 0}
            };
        }
    }
}
