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
            //note: I don't like this. Looping over the collection multiple times. Store in dicitonary?
            decimal nickels = _coins.Count(c => c == Coin.Nickel) * 5.0m;
            decimal dimes = _coins.Count(c => c == Coin.Dime) * 10.0m;
            decimal quarters = _coins.Count(c => c == Coin.Quarter) * 25.0m;

            return (nickels + dimes + quarters) / 100;
        }

        public void Accept(Coin coin)
        {
            _coins.Add(coin);
        }
    }
}
