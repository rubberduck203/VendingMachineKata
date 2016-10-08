using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vending.Core;

namespace Vending.Tests.Core
{
    [TestClass]
    public class DisplayStateTests
    {
        [TestMethod]
        public void PriceState_Soda_Displays_OneDollar()
        {
            VendingMachineState state = new PriceState(100);
            Assert.AreEqual("PRICE: $1.00", state.Display());
        }

        [TestMethod]
        public void InsertCoinState_Displays_InsertCoin()
        {
            VendingMachineState state = new InsertCoinState();
            Assert.AreEqual("INSERT COIN", state.Display());
        }
    }
}
