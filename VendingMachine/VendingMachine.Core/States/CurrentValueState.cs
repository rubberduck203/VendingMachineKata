using System.Collections.Generic;

namespace Vending.Core.States
{
    public class CurrentValueState : VendingMachineState
    {
        public CurrentValueState(StateContext context, List<Coin> returnTray, List<Coin> coins, ProductInfoRepository productInfoRepository, List<string> output) 
            : base(context, returnTray, coins, productInfoRepository, output)
        {
        }

        public override void Dispense(string sku)
        {
            var priceInCents = ProductInfoRepository.GetPrice(sku);
            var currentTotal = CurrentTotal(Coins);

            if (currentTotal < priceInCents)
            {
                Context.State = new PriceState(Context, ReturnTray, Coins, ProductInfoRepository, Output, priceInCents.Value);
            }
            else
            {
                Output.Add(sku);
                Context.State = new ThankYouState(Context, ReturnTray, Coins, ProductInfoRepository, Output);

                Coins.Clear();

                Refund(currentTotal, priceInCents);
            }
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