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
        Dime
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
            //note: can't just _coins.Sum because coins don't know their value
            var nickels = _coins.Count(c => c == Coin.Nickel);
            var dimes = _coins.Count(c => c == Coin.Dime);

            decimal nickelsValue = nickels*5.0m;
            decimal dimesValue = dimes*10.0m;

            return (nickelsValue + dimesValue)/100;
        }

        public void Accept(Coin coin)
        {
            _coins.Add(coin);
        }
    }
}
