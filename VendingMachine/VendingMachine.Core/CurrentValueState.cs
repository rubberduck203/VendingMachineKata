using System.Collections.Generic;

namespace Vending.Core
{
    public class CurrentValueState : VendingMachineState
    {
        private readonly IEnumerable<Coin> _coins;

        public CurrentValueState(IEnumerable<Coin> coins)
        {
            _coins = coins;
        }

        public string Display()
        {
            return $"{CurrentTotal(_coins):C}";
        }

        private static decimal CurrentTotal(IEnumerable<Coin> coins)
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

            decimal total = 0;
            foreach (var coinCount in counts)
            {
                total += (coinCount.Value * coinCount.Key.Value());
            }

            return ConvertCentsToDollars(total);
        }

        private static decimal ConvertCentsToDollars(decimal total)
        {
            return total / 100;
        }
    }
}