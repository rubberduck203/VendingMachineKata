using System.Collections.Generic;

namespace Vending.Core.States
{
    public class ThankYouState : VendingMachineState
    {
        public ThankYouState(List<Coin> returnTray) 
            : base(returnTray)
        {
        }

        public override string Display()
        {
            return "THANK YOU!";
        }
    }
}
