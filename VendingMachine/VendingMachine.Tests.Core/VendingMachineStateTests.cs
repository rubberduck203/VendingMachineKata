using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vending.Core;
using Vending.Core.States;

namespace Vending.Tests.Core
{
    [TestClass]
    public class VendingMachineStateTests
    {
        [TestMethod]
        public void VendingMachineState_DefaultIsInsertCoins()
        {
            Assert.IsInstanceOfType(VendingMachineState.Default, typeof(InsertCoinState));
        }

        [TestMethod]
        public void VendingMachineState_AfterDisplay_ThankYouStateTransitionsToDefault()
        {
            VendingMachine vendingMachine = new VendingMachine(new InMemoryProductInfoRepository());
            StateContext context = vendingMachine;

            context.State = new ThankYouState();

            vendingMachine.GetDisplayText();

            Assert.IsInstanceOfType(context.State, VendingMachineState.Default.GetType());
        }
    }
}
