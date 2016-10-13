using System;
using System.Collections.Generic;

namespace Vending.Core.States
{
    public abstract class VendingMachineState
    {
        protected VendingMachineState(StateContext context)
        {
            Context = context;
        }

        public static VendingMachineState Default(StateContext context)
        {
            return new InsertCoinState(context);
        } 

        protected StateContext Context { get; }

        public abstract string Display();

        public int CurrentTotal(IEnumerable<Coin> coins)
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
