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
            State.ReturnCoins(_coins, _returnTray);
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

                State.Refund(currentTotal, priceInCents, _returnTray);
            }
        }

        public void Accept(Coin coin)
        {
            if (State.AcceptCoin(coin, _coins, _returnTray))
            {
                State = new CurrentValueState(this, _coins);
            }
        }

        public string GetDisplayText()
        {
            return State.GetDisplayText();
        }
    }
}
