using System.Collections.Generic;

namespace Vending.Core.States
{
    public class ThankYouState : VendingMachineState
    {
        public ThankYouState(StateContext context, List<Coin> returnTray, List<Coin> coins, ProductInfoRepository productInfoRepository, List<string> output) 
            : base(context, returnTray, coins, productInfoRepository, output)
        {
        }

        public override string Display()
        {
            Context.State = new NoMoneyState(Context, ReturnTray, Coins, ProductInfoRepository, Output);

            return "THANK YOU!";
        }
    }
}
