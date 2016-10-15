using System.Collections.Generic;
using System.Diagnostics;

namespace Vending.Core.States
{
    internal class SoldOutState : VendingMachineState
    {
        public SoldOutState(VendingMachineState state)
            : base(state.Context, state.ReturnTray, state.Coins, state.ProductInfoRepository, state.Output)
        {
        }

        public SoldOutState(StateContext context, List<Coin> returnTray, List<Coin> coins, ProductInfoRepository productInfoRepository, List<string> output) 
            : base(context, returnTray, coins, productInfoRepository, output)
        {
        }

        public override string Display()
        {
            if (CurrentTotal() > 0)
            {
                Context.State = new CurrentValueState(this);
            }
            else
            {
                Context.State = new NoMoneyState(this);
            }

            return "SOLD OUT";
        }

        protected override void DispenseCallback(string sku)
        {
            // no op
        }
    }
}