using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending.Core
{
    public class VendingMachine
    {
        List<Coin> _coins = new List<Coin>();

        public string Display
        {
            get
            {
                if (!_coins.Any())
                {
                    return "INSERT COIN";
                }

                return "5";
            }
        }

        public void Accept(Coin coin)
        {
            _coins.Add(coin);
        }
    }

    public enum Coin { Nickel }

}
