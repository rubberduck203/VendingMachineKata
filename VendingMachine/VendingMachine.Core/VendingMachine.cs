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
        private readonly ProductInfoRepository _productInfoRepository;

        public VendingMachine(ProductInfoRepository productInfoRepository)
        {
            _productInfoRepository = productInfoRepository;
        }

        private VendingMachineState _machineState = new InsertCoinState();

        private readonly List<Coin> _coins = new List<Coin>();
        private readonly List<Coin> _returnTray = new List<Coin>();
        private readonly List<string> _output = new List<string>();
        
        public IEnumerable<Coin> ReturnTray => _returnTray;
        public IEnumerable<string> Output => _output;

        public void Dispense(string sku)
        {
            var priceInCents = _productInfoRepository.GetPrice(sku);
            var currentTotal = _machineState.CurrentTotal(_coins);

            if (currentTotal < priceInCents)
            {
                _machineState = new PriceState(priceInCents.Value);
            }
            else
            {
                _output.Add(sku);
                _machineState = new ThankYouState();

                _coins.Clear();

                Refund(currentTotal, priceInCents);
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

        private void Refund(int currentTotal, int? priceInCents)
        {
            if (currentTotal > priceInCents)
            {
                var refund = currentTotal - priceInCents;
                while (refund > 0)
                {
                    _returnTray.Add(Coin.Nickel);
                    refund -= Coin.Nickel.Value();
                }
            }
        }
    }
}
