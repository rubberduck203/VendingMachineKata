using System.Collections.Generic;
using System.Diagnostics;

namespace Vending.Core.States
{
    public class ThankYouState : VendingMachineState
    {
        public ThankYouState(VendingMachineState state)
            :base(state.Context, state.ReturnTray, state.Coins, state.ProductInfoRepository, state.Output)
        {
        }

        public override string Display()
        {
            Context.State = new NoMoneyState(Context, ReturnTray, Coins, ProductInfoRepository, Output);

            return "THANK YOU!";
        }

        public override void Dispense(string sku)
        {
            //Asserting because this action should do nothing if it happens in production.
            Debug.Assert(false, "You're trying to Dispense from an unsupported state.");
        }
    }
}
