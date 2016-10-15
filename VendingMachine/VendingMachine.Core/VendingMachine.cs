using System.Collections.Generic;
using System.Linq;
using Vending.Core.States;

namespace Vending.Core
{
    public class VendingMachine
    {
        private readonly ProductInfoRepository _productInfoRepository;

        public VendingMachine(ProductInfoRepository productInfoRepository)
        {
            _productInfoRepository = productInfoRepository;
        }

        private VendingMachineState _machineState = new NoMoneyState(new List<Coin>());

        private readonly List<Coin> _coins = new List<Coin>();
        private readonly List<string> _output = new List<string>();

        public IEnumerable<Coin> ReturnTray => _machineState.ReturnTray;
        public IEnumerable<string> Output => _output;

        public void ReturnCoins()
        {
            _machineState.ReturnTray.AddRange(_coins);
            _coins.Clear();
            _machineState = new NoMoneyState(_machineState.ReturnTray);
        }

        public void Dispense(string sku)
        {
            if (_productInfoRepository.GetQuantityAvailable(sku) == 0)
            {
                _machineState = new SoldOutState(_machineState.ReturnTray);
                return;
            }

            var priceInCents = _productInfoRepository.GetPrice(sku);
            var currentTotal = _machineState.CurrentTotal(_coins);

            if (currentTotal < priceInCents)
            {
                _machineState = new PriceState(_machineState.ReturnTray, priceInCents.Value);
            }
            else
            {
                _output.Add(sku);
                _machineState = new ThankYouState(_machineState.ReturnTray);

                _coins.Clear();

                _machineState.Refund(currentTotal, priceInCents);
            }
        }

        public void Accept(Coin coin)
        {
            if (coin.Value() == 0)
            {
                _machineState.ReturnTray.Add(coin);
                return;
            }

            _coins.Add(coin);
            _machineState = new CurrentValueState(_machineState.ReturnTray, _coins);
        }

        public string GetDisplayText()
        {
            var text = _machineState.Display();

            if (_machineState is ThankYouState || _machineState is SoldOutState)
            {
                _machineState = new NoMoneyState(_machineState.ReturnTray);
            }

            return text;
        }

    }
}
