using System.Collections.Generic;

namespace Vending.Core.States
{
    public class NoMoneyState : VendingMachineState
    {
        public NoMoneyState(VendingMachineState state)
            :base(state.Context, state.ReturnTray, state.CoinSlot, state.ProductInfoRepository, state.Output)
        { }

        public NoMoneyState(StateContext context, List<Coin> returnTray, List<Coin> coinSlot, ProductInfoRepository productInfoRepository, List<string> output)
            :base(context, returnTray, coinSlot, productInfoRepository, output)
        {
        }

        public override string Display()
        {
            return "INSERT COIN";
        }

        protected override void DispenseCallback(string sku)
        {
            var priceInCents = ProductInfoRepository.GetPrice(sku) ?? 0;
            Context.State = new PriceState(this, priceInCents);
        }
    }
}
