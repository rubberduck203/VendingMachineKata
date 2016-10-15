using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vending.Core;

namespace Vending.Tests.Core
{
    [TestClass]
    public class SoldOutTests
    {
        private ProductInfoRepository _fakeProductInfoRepository;
        private VendingMachine _vendingMachine;

        [TestInitialize]
        public void TestInitialize()
        {
            _fakeProductInfoRepository = new FakeProductInfoRepository() { QuantityAvailable = 0, Price = 65 };
            _vendingMachine = new VendingMachine(_fakeProductInfoRepository);
        }

        [TestMethod]
        public void VendingMachine_WhenSoldOutAndNoMoneyInserted_DisplaysSoldOutThenInsertCoin()
        {
            _vendingMachine.Dispense("candy");

            Assert.AreEqual("SOLD OUT", _vendingMachine.GetDisplayText());
            Assert.AreEqual("INSERT COIN", _vendingMachine.GetDisplayText());
        }

        [TestMethod]
        public void VendingMachine_WhenSoldOutAndMoneyIsInMachine_DisplaySoldOutThenCurrentAmount()
        {
            _vendingMachine.Accept(Coin.Quarter);
            _vendingMachine.Dispense("candy");

            Assert.AreEqual("SOLD OUT", _vendingMachine.GetDisplayText());
            Assert.AreEqual("$0.25", _vendingMachine.GetDisplayText());
        }
    }
}
