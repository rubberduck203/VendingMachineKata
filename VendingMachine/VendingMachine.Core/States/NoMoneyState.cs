using System.Collections.Generic;

namespace Vending.Core.States
{
    public class NoMoneyState : VendingMachineState
    {
        public NoMoneyState(StateContext context, List<Coin> returnTray, List<Coin> coins, ProductInfoRepository productInfoRepository, List<string> output)
            :base(context, returnTray, coins, productInfoRepository, output)
        {
        }

        public override string Display()
        {
            return "INSERT COIN";
        }

        public override void Dispense(string sku)
        {
            var priceInCents = ProductInfoRepository.GetPrice(sku) ?? 0;
            Context.State = new PriceState(Context, ReturnTray, Coins, ProductInfoRepository, Output, priceInCents);
        }
    }
}
