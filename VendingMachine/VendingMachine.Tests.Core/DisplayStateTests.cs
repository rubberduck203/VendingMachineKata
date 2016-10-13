using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vending.Core;
using Vending.Core.States;

namespace Vending.Tests.Core
{
    [TestClass]
    public class DisplayStateTests
    {
        [TestMethod]
        public void PriceState_Soda_Displays_OneDollar()
        {
            VendingMachineState state = new PriceState(new FakeStateContext(), 100);
            Assert.AreEqual("PRICE: $1.00", state.Display());
        }

        [TestMethod]
        public void InsertCoinState_Displays_InsertCoin()
        {
            VendingMachineState state = new InsertCoinState(new FakeStateContext());
            Assert.AreEqual("INSERT COIN", state.Display());
        }
    }

    internal class FakeStateContext : StateContext
    {
        public VendingMachineState State
        {
            get { return null; }
            set { }
        }
    }
}
