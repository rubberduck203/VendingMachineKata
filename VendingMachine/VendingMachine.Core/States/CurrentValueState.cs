using System.Collections.Generic;

namespace Vending.Core.States
{
    public class CurrentValueState : VendingMachineState
    {
        private readonly IEnumerable<Coin> _coins;

        public CurrentValueState(IEnumerable<Coin> coins)
        {
            _coins = coins;
        }

        public override string Display()
        {
            var total = ConvertCentsToDollars(CurrentTotal(_coins));
            return $"{total:C}";
        }

        private static decimal ConvertCentsToDollars(decimal total)
        {
            return total / 100;
        }
    }
}