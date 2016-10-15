using System.Collections.Generic;
using System.Linq;
using Vending.Core.States;

namespace Vending.Core
{
    public interface StateContext
    {
        VendingMachineState State { get; set; }
    }

    public class VendingMachine : StateContext
    {
        private readonly ProductInfoRepository _productInfoRepository;

        public VendingMachine(ProductInfoRepository productInfoRepository)
        {
            _productInfoRepository = productInfoRepository;
        }

        public VendingMachineState State { get; set; } = new NoMoneyState(new List<Coin>());

        private readonly List<Coin> _coins = new List<Coin>();
        private readonly List<string> _output = new List<string>();

        public IEnumerable<Coin> ReturnTray => State.ReturnTray;
        public IEnumerable<string> Output => _output;

        public void ReturnCoins()
        {
            State.ReturnTray.AddRange(_coins);
            _coins.Clear();
            State = new NoMoneyState(State.ReturnTray);
        }

        public void Dispense(string sku)
        {
            if (_productInfoRepository.GetQuantityAvailable(sku) == 0)
            {
                State = new SoldOutState(State.ReturnTray);
                return;
            }

            var priceInCents = _productInfoRepository.GetPrice(sku);
            var currentTotal = State.CurrentTotal(_coins);

            if (currentTotal < priceInCents)
            {
                State = new PriceState(State.ReturnTray, priceInCents.Value);
            }
            else
            {
                _output.Add(sku);
                State = new ThankYouState(State.ReturnTray);

                _coins.Clear();

                State.Refund(currentTotal, priceInCents);
            }
        }

        public void Accept(Coin coin)
        {
            if (coin.Value() == 0)
            {
                State.ReturnTray.Add(coin);
                return;
            }

            _coins.Add(coin);
            State = new CurrentValueState(State.ReturnTray, _coins);
        }

        public string GetDisplayText()
        {
            var text = State.Display();

            if (State is ThankYouState || State is SoldOutState)
            {
                State = new NoMoneyState(State.ReturnTray);
            }

            return text;
        }

    }
}
