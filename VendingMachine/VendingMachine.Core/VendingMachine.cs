using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vending.Core
{
    public class VendingMachine
    {
        private VendingMachineState _machineState = new InsertCoinState();

        private readonly List<Coin> _coins = new List<Coin>();
        private readonly List<Coin> _returnTray = new List<Coin>();
        private readonly List<string> _output = new List<string>();
        
        public IEnumerable<Coin> ReturnTray => _returnTray;
        public IEnumerable<string> Output => _output;

        public void Dispense(string soda)
        {
            const int priceInCents = 100; //soda
            if (_machineState.CurrentTotal(_coins) < priceInCents)
            {
                _machineState = new PriceState();
            }
            else
            {
                _output.Add(soda);
                _machineState = new ThankYouState();

                _coins.Clear();

                //hardcoded for test
                _returnTray.Add(Coin.Quarter);
                _returnTray.Add(Coin.Quarter);
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
            var text = _machineState.Display();

            if (_machineState is ThankYouState)
            {
                _machineState = new InsertCoinState();
            }

            return text;
        }
    }
}
