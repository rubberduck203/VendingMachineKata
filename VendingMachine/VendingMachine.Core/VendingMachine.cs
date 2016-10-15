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
            State = new NoMoneyState(this, new List<Coin>(), new List<Coin>(), productInfoRepository);
        }

        public VendingMachineState State { get; set; }

        private readonly List<string> _output = new List<string>();

        public IEnumerable<Coin> ReturnTray => State.ReturnTray;
        public IEnumerable<string> Output => _output;


        public void ReturnCoins()
        {
            State.ReturnTray.AddRange(State.Coins);
            State.Coins.Clear();
            State = new NoMoneyState(this, State.ReturnTray, State.Coins, _productInfoRepository);
        }

        public void Dispense(string sku)
        {
            if (_productInfoRepository.GetQuantityAvailable(sku) == 0)
            {
                State = new SoldOutState(this, State.ReturnTray, State.Coins, _productInfoRepository);
                return;
            }

            if (State is NoMoneyState)
            {
                State.Dispense(sku);
                return;
            }

            var priceInCents = _productInfoRepository.GetPrice(sku);
            var currentTotal = State.CurrentTotal(State.Coins);

            if (currentTotal < priceInCents)
            {
                State = new PriceState(this, State.ReturnTray, State.Coins, priceInCents.Value);
            }
            else
            {
                _output.Add(sku);
                State = new ThankYouState(this, State.ReturnTray, State.Coins);

                State.Coins.Clear();

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

            State.Coins.Add(coin);
            State = new CurrentValueState(this, State.ReturnTray, State.Coins);
        }

        public string GetDisplayText()
        {
            var text = State.Display();

            if (State is ThankYouState )
            {
                State = new NoMoneyState(this, State.ReturnTray, State.Coins, _productInfoRepository);
            }

            return text;
        }

    }
}
