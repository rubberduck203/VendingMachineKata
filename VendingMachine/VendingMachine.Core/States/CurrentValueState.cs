namespace Vending.Core.States
{
    public class CurrentValueState : VendingMachineState
    {
        public CurrentValueState(VendingMachineState state)
            : base(state.Context, state.ReturnTray, state.CoinSlot, state.ProductInfoRepository, state.Output)
        {
        }

        protected override void DispenseCallback(string sku)
        {
            var priceInCents = ProductInfoRepository.GetPrice(sku);
            var currentTotal = CurrentTotal();

            if (currentTotal < priceInCents)
            {
                Context.State = new PriceState(this, priceInCents.Value);
            }
            else
            {
                Output.Add(sku);
                ProductInfoRepository.DecrementProductCount(sku);
                CoinSlot.Clear();

                Refund(currentTotal, priceInCents);

                Context.State = new ThankYouState(this);
            }
        }

        public override string Display()
        {
            var total = ConvertCentsToDollars(CurrentTotal());
            return $"{total:C}";
        }

        private static decimal ConvertCentsToDollars(decimal total)
        {
            return total / 100;
        }
    }
}