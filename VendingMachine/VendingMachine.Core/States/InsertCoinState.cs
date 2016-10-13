namespace Vending.Core.States
{
    public class InsertCoinState : VendingMachineState
    {
        public InsertCoinState(StateContext context) 
            : base(context)
        { }

        public override string Display()
        {
            return "INSERT COIN";
        }
    }
}
