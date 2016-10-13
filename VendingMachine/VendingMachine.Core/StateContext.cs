using Vending.Core.States;

namespace Vending.Core
{
    public interface StateContext
    {
        VendingMachineState State { get; set; }
    }
}