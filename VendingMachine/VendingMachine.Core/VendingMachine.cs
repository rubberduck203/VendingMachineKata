using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vending.Core
{
    public class VendingMachine
    {
        private readonly List<Coin> _coins = new List<Coin>();
        private readonly List<Coin> _returnTray = new List<Coin>();

        public IEnumerable<Coin> ReturnTray => _returnTray;

        public void Accept(Coin coin)
        {
            if (GetCoinValue(coin) == 0)
            {
                _returnTray.Add(coin);
                return;
            }

            _coins.Add(coin);
        }

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
                total += (coinCount.Value * GetCoinValue(coinCount.Key));
            }

            return ConvertCentsToDollars(total);
        }

        private static decimal ConvertCentsToDollars(decimal total)
        {
            return total / 100;
        }

        private static int GetCoinValue(Coin coinType)
        {
            switch (coinType)
            {
                case Coin.Nickel:
                    return 5;
                case Coin.Dime:
                    return 10;
                case Coin.Quarter:
                    return 25;
                default:
                    return 0;
            }
        }
    }
}
