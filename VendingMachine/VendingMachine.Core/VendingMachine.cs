using System.Collections.Generic;
using Vending.Core.States;

namespace Vending.Core
{
    public interface StateContext
    {
        VendingMachineState State { get; set; }
    }

    public class VendingMachine : StateContext
    {
        public VendingMachine(ProductInfoRepository productInfoRepository)
        {
            State = new NoMoneyState(this, new List<Coin>(), new List<Coin>(), productInfoRepository, new List<string>(), new List<Coin>());
        }

        public VendingMachineState State { get; set; }

        public IEnumerable<Coin> ReturnTray => State.ReturnTray;
        public IEnumerable<string> Output => State.Output;

        public IEnumerable<Coin> Vault => State.Vault;

        public void ReturnCoins()
        {
            State.ReturnCoins();
        }

        public void Dispense(string sku)
        {
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
