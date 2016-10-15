using System.Collections.Generic;
using System.Linq;

namespace Vending.Core.States
{
    public abstract class VendingMachineState
    {
        private readonly List<Coin> _returnTray;

        protected VendingMachineState(List<Coin> returnTray)
        {
            _returnTray = returnTray;
        }

        public List<Coin> ReturnTray => _returnTray;
        public abstract string Display();

        public  int CurrentTotal(IEnumerable<Coin> coins)
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

        public void Refund(int currentTotal, int? priceInCents)
        {
            var calculator = new RefundCalculator();
            var refund = calculator.CalculateRefund(priceInCents ?? 0, currentTotal);

            foreach (var coinCount in refund)
            {
                _returnTray.AddRange(Enumerable.Repeat(coinCount.Key, coinCount.Value));
            }
        }
    }
}
