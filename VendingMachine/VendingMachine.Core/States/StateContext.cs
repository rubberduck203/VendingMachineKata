namespace Vending.Core.States
{
    public interface StateContext
    {
        VendingMachineState State { get; set; }
    }
}