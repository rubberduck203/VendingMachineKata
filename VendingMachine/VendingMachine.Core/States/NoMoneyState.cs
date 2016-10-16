using System.Collections.Generic;

namespace Vending.Core.States
{
    public class NoMoneyState : VendingMachineState
    {
        public NoMoneyState(VendingMachineState state)
            :base(state.Context, state.ReturnTray, state.CoinSlot, state.ProductInfoRepository, state.Output, state.Vault)
        { }

        public NoMoneyState(StateContext context, List<Coin> returnTray, List<Coin> coinSlot, ProductInfoRepository productInfoRepository, List<string> output, List<Coin> vault)
            :base(context, returnTray, coinSlot, productInfoRepository, output, vault)
        {
        }

        public override string Display()
        {
            var refundCalculator = new RefundCalculator();
            return refundCalculator.CanMakeChange(Vault) ? "INSERT COIN" : "EXACT CHANGE ONLY";
        }

        protected override void DispenseCallback(string sku)
        {
            var priceInCents = ProductInfoRepository.GetPrice(sku) ?? 0;
            Context.State = new PriceState(this, priceInCents);
        }
    }
}
