namespace Vending.Core.States
{
    public class ThankYouState : VendingMachineState
    {
        public ThankYouState(StateContext context) 
            : base(context)
        { }

        public override string Display()
        {
            Context.State = Default(Context);

            return "THANK YOU!";
        }
    }
}
