using System.Collections.Generic;

namespace Vending.Core.States
{
    internal class SoldOutState : VendingMachineState
    {
        public SoldOutState(List<Coin> returnTray) 
            : base(returnTray)
        {
        }

        public override string Display()
        {
            return "SOLD OUT";
        }
    }
}