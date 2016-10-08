using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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

            return (counts[Coin.Nickel] * 5.0m + counts[Coin.Dime] * 10.0m + counts[Coin.Quarter] * 25.0m) / 100;
        }

        public void Accept(Coin coin)
        {
            _coins.Add(coin);
        }
    }
}
