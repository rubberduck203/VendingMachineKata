using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vending.Core;

namespace Vending.Tests.Core
{
    [TestClass]
    public class VendingMachineTests
    {
        private VendingMachine _vendingMachine;

        [TestInitialize]
        public void TestInitialize()
        {
            _vendingMachine = new VendingMachine();
        }

        [TestMethod]
        public void VendingMachine_OnStartUp_Displays_InsertCoin()
        {
            Assert.AreEqual("INSERT COIN", _vendingMachine.GetDisplayText());
        }

        [TestMethod]
        public void VendingMachine_GivenANickel_Displays_5()
        {
            _vendingMachine.Accept(Coin.Nickel);
            Assert.AreEqual("$0.05", _vendingMachine.GetDisplayText());
        }

        [TestMethod]
        public void VendingMachine_GivenTwoNickels_Displays_10()
        {
            _vendingMachine.Accept(Coin.Nickel);
            _vendingMachine.Accept(Coin.Nickel);
            Assert.AreEqual("$0.10", _vendingMachine.GetDisplayText());
        }


    }
}
