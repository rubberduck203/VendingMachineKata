using System.Collections.Generic;

namespace Vending.Core.States
{
    public class CurrentValueState : VendingMachineState
    {
        public CurrentValueState(StateContext context, List<Coin> returnTray, List<Coin> coins) 
            : base(context, returnTray, coins)
        {
        }

        public override string Display()
        {
            var total = ConvertCentsToDollars(CurrentTotal(Coins));
            return $"{total:C}";
        }

        private static decimal ConvertCentsToDollars(decimal total)
        {
            return total / 100;
        }
    }
}