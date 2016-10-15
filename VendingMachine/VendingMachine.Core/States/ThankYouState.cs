using System.Collections.Generic;

namespace Vending.Core.States
{
    public class ThankYouState : VendingMachineState
    {
        private readonly ProductInfoRepository _productInfoRepository;

        public ThankYouState(StateContext context, List<Coin> returnTray, List<Coin> coins, ProductInfoRepository productInfoRepository) 
            : base(context, returnTray, coins)
        {
            _productInfoRepository = productInfoRepository;
        }

        public override string Display()
        {
            Context.State = new NoMoneyState(Context, ReturnTray, Coins, _productInfoRepository);

            return "THANK YOU!";
        }
    }
}
