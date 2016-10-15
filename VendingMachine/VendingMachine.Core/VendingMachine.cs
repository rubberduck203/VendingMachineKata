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
        public VendingMachine(ProductInfoRepository productInfoRepository)
        {
            // Machine is preloaded, should probably inject the vault
            var vault = new List<Coin>();
            vault.AddRange(Enumerable.Repeat(Coin.Quarter, 10));
            vault.AddRange(Enumerable.Repeat(Coin.Dime, 10));
            vault.AddRange(Enumerable.Repeat(Coin.Nickel, 10));

            State = new NoMoneyState(this, new List<Coin>(), new List<Coin>(), productInfoRepository, new List<string>(), vault);
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
