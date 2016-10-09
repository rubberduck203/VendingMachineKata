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
            var quarters = 0;

            if (nickels >= 5)
            {
                quarters = nickels / 5;
                nickels -= (quarters * 5);
            }

            if (nickels >= 2)
            {
                dimes = nickels / 2;
                nickels -= (dimes * 2);
            }

            return new Dictionary<Coin, int>()
            {
                {Coin.Nickel, nickels},
                {Coin.Dime, dimes},
                {Coin.Quarter, quarters}
            };
        }
    }
}
