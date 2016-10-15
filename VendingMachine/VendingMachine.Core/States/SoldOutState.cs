using System.Collections.Generic;
using System.Diagnostics;

namespace Vending.Core.States
{
    internal class SoldOutState : VendingMachineState
    {
        public SoldOutState(StateContext context, List<Coin> returnTray, List<Coin> coins, ProductInfoRepository productInfoRepository, List<string> output) 
            : base(context, returnTray, coins, productInfoRepository, output)
        {
        }

        public override string Display()
        {
            if (CurrentTotal(Coins) > 0)
            {
                Context.State = new CurrentValueState(this);
            }
            else
            {
                Context.State = new NoMoneyState(this);
            }

            return "SOLD OUT";
        }

        public override void Dispense(string sku)
        {
            //Asserting because this action should do nothing if it happens in production.
            Debug.Assert(false, "You're trying to Dispense from an unsupported state.");
        }
    }
}