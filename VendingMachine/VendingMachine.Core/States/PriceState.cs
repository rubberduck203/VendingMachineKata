using System.Collections.Generic;

namespace Vending.Core.States
{
    public class PriceState : VendingMachineState
    {
        private readonly decimal _priceInCents;

        public PriceState(VendingMachineState state, int priceInCents)
            :this(state.Context, state.ReturnTray, state.CoinSlot, state.ProductInfoRepository, state.Output, priceInCents)
        {
        }

        public PriceState(StateContext context, List<Coin> returnTray, List<Coin> coinSlot, ProductInfoRepository productInfoRepository, List<string> output, int priceInCents)
            :base(context, returnTray, coinSlot, productInfoRepository, output)
        {
            _priceInCents = priceInCents;
        }

        public override string Display()
        {
            return $"PRICE: {_priceInCents/100:C}";
        }

        protected override void DispenseCallback(string sku)
        {
            // no op
        }
    }
}
