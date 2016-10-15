using System.Collections.Generic;

namespace Vending.Core.States
{
    public class NoMoneyState : VendingMachineState
    {
        public override string Display()
        {
            return "INSERT COIN";
        }

        public override void Refund()
        {
            // intentional no op
        }
    }
}
