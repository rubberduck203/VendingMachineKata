using System.Collections.Generic;

namespace Vending.Core.States
{
    public class PriceState : VendingMachineState
    {
        private readonly decimal _priceInCents;

        public PriceState(StateContext context, List<Coin> returnTray, List<Coin> coins, int priceInCents)
            :base(context, returnTray, coins)
        {
            _priceInCents = priceInCents;
        }

        public override string Display()
        {
            return $"PRICE: {_priceInCents/100:C}";
        }
    }
}
