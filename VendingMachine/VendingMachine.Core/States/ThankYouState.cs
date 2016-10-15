using System.Collections.Generic;

namespace Vending.Core.States
{
    public class ThankYouState : VendingMachineState
    {
        public ThankYouState(StateContext context, List<Coin> returnTray, List<Coin> coins) 
            : base(context, returnTray, coins)
        {
        }

        public override string Display()
        {
            return "THANK YOU!";
        }
    }
}
