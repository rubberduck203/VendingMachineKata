using System.Collections.Generic;

namespace Vending.Core.States
{
    public class NoMoneyState : VendingMachineState
    {
        private readonly ProductInfoRepository _productInfoRepository;

        public NoMoneyState(StateContext context, List<Coin> returnTray, List<Coin> coins, ProductInfoRepository productInfoRepository)
            :base(context, returnTray, coins)
        {
            _productInfoRepository = productInfoRepository;
        }

        public override string Display()
        {
            return "INSERT COIN";
        }

        public override void Dispense(string sku)
        {
            var priceInCents = _productInfoRepository.GetPrice(sku) ?? 0;
            Context.State = new PriceState(Context, ReturnTray, Coins, priceInCents);
        }
    }
}
