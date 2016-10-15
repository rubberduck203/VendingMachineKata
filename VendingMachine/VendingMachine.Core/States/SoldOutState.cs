using System.Collections.Generic;

namespace Vending.Core.States
{
    internal class SoldOutState : VendingMachineState
    {
        private readonly ProductInfoRepository _productInfoRepository;

        public SoldOutState(StateContext context, List<Coin> returnTray, List<Coin> coins, ProductInfoRepository productInfoRepository) 
            : base(context, returnTray, coins)
        {
            _productInfoRepository = productInfoRepository;
        }

        public override string Display()
        {
            if (CurrentTotal(Coins) > 0)
            {
                Context.State = new CurrentValueState(Context, ReturnTray, Coins);
            }
            else
            {
                Context.State = new NoMoneyState(Context, ReturnTray, Coins, _productInfoRepository);
            }

            return "SOLD OUT";
        }
    }
}