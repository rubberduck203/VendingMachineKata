using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vending.Core
{
    public class VendingMachine
    {
        private readonly List<Coin> _coins = new List<Coin>();
        private readonly List<Coin> _returnTray = new List<Coin>();
        private VendingMachineState _machineState = new InsertCoinState();

        public IEnumerable<Coin> ReturnTray => _returnTray;

        public void Dispense(string soda)
        {
            if (!_coins.Any())
            {
                _machineState = new PriceState();
            }
            else
            {
                _machineState = new ThankYouState();
            }
        }

        public void Accept(Coin coin)
        {
            if (coin.Value() == 0)
            {
                _returnTray.Add(coin);
                return;
            }

            _coins.Add(coin);
            _machineState = new CurrentValueState(_coins);
        }

        public string GetDisplayText()
        {
            //if (!_coins.Any())
            //{
            //    return _machineState.Display();
            //}

            return _machineState.Display();
        }
    }
}
