using System.Collections.Generic;

namespace Vending.Core.States
{
    public class CurrentValueState : VendingMachineState
    {
        private readonly ProductInfoRepository _productInfoRepository;
        private readonly List<string> _output;

        public CurrentValueState(StateContext context, List<Coin> returnTray, List<Coin> coins, ProductInfoRepository productInfoRepository, List<string> output) 
            : base(context, returnTray, coins)
        {
            _productInfoRepository = productInfoRepository;
            _output = output;
        }

        public override void Dispense(string sku)
        {
            var priceInCents = _productInfoRepository.GetPrice(sku);
            var currentTotal = CurrentTotal(Coins);

            if (currentTotal < priceInCents)
            {
                Context.State = new PriceState(Context, ReturnTray, Coins, priceInCents.Value);
            }
            else
            {
                _output.Add(sku);
                Context.State = new ThankYouState(Context, ReturnTray, Coins, _productInfoRepository);

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