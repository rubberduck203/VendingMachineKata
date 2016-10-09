using System.Collections.Generic;

namespace Vending.Core
{
    public class RefundCalculator
    {
        public IDictionary<Coin, int> CalculateRefund(int priceInCents, int paidInCents)
        {
            /* Note: I'm not particularly fond of the implementation here.
             * I don't care for the duplication, or the side effects.
             * I suspect there's a more functional way to do this.
             * That said, the implementation is exceedingly unlikely to 
             * change in the future, so goood enough is good enough.
             */

            var refundValue = paidInCents - priceInCents;

            var nickels = refundValue / Coin.Nickel.Value();

            var dimes = 0;
            var quarters = 0;

            const int nickelsPerQuarter = 5;
            if (nickels >= nickelsPerQuarter)
            {
                quarters = nickels / nickelsPerQuarter;
                nickels -= (quarters * nickelsPerQuarter);
            }

            const int nickelsPerDime = 2;
            if (nickels >= nickelsPerDime)
            {
                dimes = nickels / nickelsPerDime;
                nickels -= (dimes * nickelsPerDime);
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
