using System;
using System.Collections.Generic;

namespace Vending.Core.States
{
    public abstract class VendingMachineState
    {
        public static VendingMachineState Default => new InsertCoinState();

        public abstract string Display();

        public virtual int CurrentTotal(IEnumerable<Coin> coins)
        {
            var counts = new Dictionary<Coin, int>()
            {
                {Coin.Nickel, 0},
                {Coin.Dime, 0},
                {Coin.Quarter, 0}
            };

            foreach (var coin in coins)
            {
                counts[coin]++;
            }

            var total = 0;
            foreach (var coinCount in counts)
            {
                total += (coinCount.Value * coinCount.Key.Value());
            }

            return total;
        }
    }
}
