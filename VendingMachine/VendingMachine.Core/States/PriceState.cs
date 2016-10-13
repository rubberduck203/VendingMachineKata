namespace Vending.Core.States
{
    public class PriceState : VendingMachineState
    {
        private readonly decimal _priceInCents;

        public PriceState(StateContext context, int priceInCents)
            :base(context)
        {
            _priceInCents = priceInCents;
        }

        public override string GetDisplayText()
        {
            return $"PRICE: {_priceInCents/100:C}";
        }
    }
}
