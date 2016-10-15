using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vending.Core;

namespace Vending.Tests.Core
{
    [TestClass]
    public class SoldOutTests
    {
        [TestMethod]
        public void VendingMachine_WhenSoldOutAndNoMoneyInserted_DisplaysSoldOutThenInsertCoin()
        {
            var fakeProductInfoRepository = new FakeProductInfoRepository() { QuantityAvailable = 0 };
            var vendingMachine = new VendingMachine(fakeProductInfoRepository);

            vendingMachine.Dispense("candy");

            Assert.AreEqual("SOLD OUT", vendingMachine.GetDisplayText());
            Assert.AreEqual("INSERT COIN", vendingMachine.GetDisplayText());
        }

        [Ignore]
        [TestMethod]
        public void VendingMachine_WhenSoldOutAndMoneyIsInMachine_DisplaySoldOutThenCurrentAmount()
        {
            var fakeProductInfoRepository = new FakeProductInfoRepository() { QuantityAvailable = 0, Price = 65 };
            var vendingMachine = new VendingMachine(fakeProductInfoRepository);

            vendingMachine.Dispense("candy");

            Assert.AreEqual("SOLD OUT", vendingMachine.GetDisplayText());
            Assert.AreEqual("$0.65", vendingMachine.GetDisplayText());
        }
    }
}
