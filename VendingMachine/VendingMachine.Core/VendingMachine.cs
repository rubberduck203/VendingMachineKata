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

        private VendingMachineState _machineState = new InsertCoinState();

        private readonly List<Coin> _coins = new List<Coin>();
        private readonly List<Coin> _returnTray = new List<Coin>();
        private readonly List<string> _output = new List<string>();

        public IEnumerable<Coin> ReturnTray => _returnTray;
        public IEnumerable<string> Output => _output;

        public void ReturnCoins()
        {
            _returnTray.AddRange(_coins);
            _coins.Clear();
            _machineState = VendingMachineState.Default;
        }

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
                _machineState = VendingMachineState.Default;
            }

            return text;
        }

        private void Refund(int currentTotal, int? priceInCents)
        {
            var calculator = new RefundCalculator();
            var refund = calculator.CalculateRefund(priceInCents ?? 0, currentTotal);

            foreach (var coinCount in refund)
            {
                _returnTray.AddRange(Enumerable.Repeat(coinCount.Key, coinCount.Value));
            }
        }
    }
}
