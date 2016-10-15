using System.Collections.Generic;

namespace Vending.Core.States
{
    public class PriceState : VendingMachineState
    {
        private readonly decimal _priceInCents;

        public PriceState(StateContext context, List<Coin> returnTray, List<Coin> coins, ProductInfoRepository productInfoRepository, List<string> output, int priceInCents)
            :base(context, returnTray, coins, productInfoRepository, output)
        {
            _priceInCents = priceInCents;
        }

        public override string Display()
        {
            return $"PRICE: {_priceInCents/100:C}";
        }
    }
}
