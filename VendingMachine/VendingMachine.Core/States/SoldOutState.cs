using System.Collections.Generic;

namespace Vending.Core.States
{
    internal class SoldOutState : VendingMachineState
    {
        private readonly ProductInfoRepository _productInfoRepository;
        private readonly List<string> _output;

        public SoldOutState(StateContext context, List<Coin> returnTray, List<Coin> coins, ProductInfoRepository productInfoRepository, List<string> output) 
            : base(context, returnTray, coins)
        {
            _productInfoRepository = productInfoRepository;
            _output = output;
        }

        public override string Display()
        {
            if (CurrentTotal(Coins) > 0)
            {
                Context.State = new CurrentValueState(Context, ReturnTray, Coins, _productInfoRepository, _output);
            }
            else
            {
                Context.State = new NoMoneyState(Context, ReturnTray, Coins, _productInfoRepository);
            }

            return "SOLD OUT";
        }
    }
}