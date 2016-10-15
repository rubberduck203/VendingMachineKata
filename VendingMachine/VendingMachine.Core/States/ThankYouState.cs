using System.Collections.Generic;

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
    }
}
