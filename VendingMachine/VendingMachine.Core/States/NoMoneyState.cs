using System.Collections.Generic;

namespace Vending.Core.States
{
    public class NoMoneyState : VendingMachineState
    {
        public NoMoneyState(List<Coin> returnTray)
            :base(returnTray)
        {
        }

        public override string Display()
        {
            return "INSERT COIN";
        }
    }
}
