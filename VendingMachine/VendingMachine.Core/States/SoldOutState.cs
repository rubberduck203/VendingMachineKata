namespace Vending.Core.States
{
    internal class SoldOutState : VendingMachineState
    {
        public override string Display()
        {
            return "SOLD OUT";
        }
    }
}