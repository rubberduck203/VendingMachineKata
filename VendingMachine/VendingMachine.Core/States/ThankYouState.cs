namespace Vending.Core.States
{
    public class ThankYouState : VendingMachineState
    {
        public ThankYouState(VendingMachineState state)
            :base(state.Context, state.ReturnTray, state.CoinSlot, state.ProductInfoRepository, state.Output, state.Vault)
        {
        }

        public override string Display()
        {
            Context.State = new NoMoneyState(this);

            return "THANK YOU!";
        }

        protected override void DispenseCallback(string sku)
        {
            // no op
        }
    }
}
