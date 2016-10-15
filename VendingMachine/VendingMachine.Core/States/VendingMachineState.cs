using System;
using System.Collections.Generic;
using System.Linq;

namespace Vending.Core.States
{
    public abstract class VendingMachineState
    {
        public static VendingMachineState Default(StateContext context)
        {
            return new InsertCoinState(context);
        }

        protected VendingMachineState(StateContext context)
        {
            Context = context;
        }

        protected StateContext Context { get; }

        public abstract string GetDisplayText();

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

        public void Refund(int currentTotal, int? priceInCents, List<Coin> returnTray)
        {
            var calculator = new RefundCalculator();
            var refund = calculator.CalculateRefund(priceInCents ?? 0, currentTotal);

            foreach (var coinCount in refund)
            {
                returnTray.AddRange(Enumerable.Repeat(coinCount.Key, coinCount.Value));
            }
        }

        public bool AcceptCoin(Coin coin, List<Coin> coins, List<Coin> returnTray)
        {
            if (coin.Value() == 0)
            {
                returnTray.Add(coin);
                return false;
            }

            coins.Add(coin);
            return true;
        }

        public void ReturnCoins(List<Coin> coins, List<Coin> returnTray)
        {
            returnTray.AddRange(coins);
            coins.Clear();
            Context.State = VendingMachineState.Default(Context);
        }
    }
}
