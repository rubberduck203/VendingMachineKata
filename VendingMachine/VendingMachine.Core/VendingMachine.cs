using System.Collections.Generic;
using System.Linq;
using Vending.Core.States;

namespace Vending.Core
{
    public class VendingMachine : StateContext
    {
        private readonly ProductInfoRepository _productInfoRepository;

        public VendingMachine(ProductInfoRepository productInfoRepository)
        {
            _productInfoRepository = productInfoRepository;
            State = VendingMachineState.Default(this);
        }

        public VendingMachineState State { get; set; } 

        private readonly List<Coin> _coins = new List<Coin>();
        private readonly List<Coin> _returnTray = new List<Coin>();
        private readonly List<string> _output = new List<string>();

        public IEnumerable<Coin> ReturnTray => _returnTray;
        public IEnumerable<string> Output => _output;

        public void ReturnCoins()
        {
            _returnTray.AddRange(_coins);
            _coins.Clear();
            State = VendingMachineState.Default(this);
        }

        public void Dispense(string sku)
        {
            var priceInCents = _productInfoRepository.GetPrice(sku);
            var currentTotal = State.CurrentTotal(_coins);

            if (currentTotal < priceInCents)
            {
                State = new PriceState(this, priceInCents.Value);
            }
            else
            {
                _output.Add(sku);
                State = new ThankYouState(this);

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
            State = new CurrentValueState(this, _coins);
        }

        public string GetDisplayText()
        {
            var text = State.Display();
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
