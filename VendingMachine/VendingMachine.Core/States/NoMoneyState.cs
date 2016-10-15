using System.Collections.Generic;

namespace Vending.Core.States
{
    public class NoMoneyState : VendingMachineState
    {
        private readonly List<Coin> _returnTray = new List<Coin>();
        public IEnumerable<Coin> ReturnTray => _returnTray;

        public override string Display()
        {
            return "INSERT COIN";
        }

        public void Refund()
        {
            
        }
    }
}
