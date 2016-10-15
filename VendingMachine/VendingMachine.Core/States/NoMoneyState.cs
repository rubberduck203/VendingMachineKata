namespace Vending.Core.States
{
    public class NoMoneyState : VendingMachineState
    {
        public override string Display()
        {
            return "INSERT COIN";
        }
    }
}
