using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vending.Core;

namespace Vending.Tests.Core
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        public void VendingMachine_OnStartUp_Displays_InsertCoin()
        {
            var vendingMachine = new VendingMachine();
            Assert.AreEqual("INSERT COIN", vendingMachine.GetDisplayText());
        }

        [TestMethod]
        public void VendingMachine_GivenANickel_Displays_5()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.Accept(Coin.Nickel);

            Assert.AreEqual("5", vendingMachine.GetDisplayText());
        }
    }
}
