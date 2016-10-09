using System.Collections.Generic;

namespace Vending.Core
{
    public class RefundCalculator
    {
        public IDictionary<Coin, int> CalculateRefund(int priceInCents, int paidInCents)
        {
            var refundValue = paidInCents - priceInCents;
            var nickels = refundValue / 5;

            return new Dictionary<Coin, int>()
            {
                {Coin.Nickel, nickels},
                {Coin.Dime, 0},
                {Coin.Quarter, 0}
            };
        }
    }
}
