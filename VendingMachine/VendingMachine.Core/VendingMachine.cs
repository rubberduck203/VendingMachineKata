using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vending.Core
{
    public enum Coin
    {
        Nickel,
        Dime,
        Quarter
    }

    public class VendingMachine
    {
        private readonly List<Coin> _coins = new List<Coin>();

        public string GetDisplayText()
        {
            if (!_coins.Any())
            {
                return "INSERT COIN";
            }

            return $"{CurrentTotal():C}";
        }

        private decimal CurrentTotal()
        {
            var counts = new Dictionary<Coin, int>()
            {
                {Coin.Nickel, 0},
                {Coin.Dime, 0},
                {Coin.Quarter, 0}
            };

            foreach (var coin in _coins)
            {
                counts[coin]++;
            }

            decimal total = 0;
            foreach (var coinCount in counts)
            {
                total += (coinCount.Value * CoinValue(coinCount.Key));
            }

            return total/100;

            //return (counts[Coin.Nickel] * 5.0m + counts[Coin.Dime] * 10.0m + counts[Coin.Quarter] * 25.0m) / 100;
        }

        private decimal CoinValue(Coin coinType)
        {
            switch (coinType)
            {
                case Coin.Nickel:
                    return 5.0m;
                case Coin.Dime:
                    return 10.0m;
                case Coin.Quarter:
                    return 25.0m;
                default:
                    return 0.0m;
            }
        }

        public void Accept(Coin coin)
        {
            _coins.Add(coin);
        }
    }
}
