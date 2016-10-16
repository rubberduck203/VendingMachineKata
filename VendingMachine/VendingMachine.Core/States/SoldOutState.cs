using System.Collections.Generic;

namespace Vending.Core.States
{
    internal class SoldOutState : VendingMachineState
    {
        public SoldOutState(VendingMachineState state)
            : base(state.Context, state.ReturnTray, state.CoinSlot, state.ProductInfoRepository, state.Output, state.Vault)
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