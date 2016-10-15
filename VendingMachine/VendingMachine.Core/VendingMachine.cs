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
            State = new NoMoneyState(this, new List<Coin>(), new List<Coin>(), productInfoRepository, _output);
        }

        public VendingMachineState State { get; set; }

        private readonly List<string> _output = new List<string>();

        public IEnumerable<Coin> ReturnTray => State.ReturnTray;
        public IEnumerable<string> Output => _output;


        public void ReturnCoins()
        {
            State.ReturnCoins();
        }

        public void Dispense(string sku)
        {
            if (_productInfoRepository.GetQuantityAvailable(sku) == 0)
            {
                State = new SoldOutState(this, State.ReturnTray, State.Coins, _productInfoRepository, _output);
                return;
            }

            State.Dispense(sku);
        }

        public void Accept(Coin coin)
        {
            State.Accept(coin);
        }

        public string GetDisplayText()
        {
            return State.Display();
        }

    }
}
