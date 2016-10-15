using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vending.Core;
using Vending.Core.States;

namespace Vending.Tests.Core
{
    [TestClass]
    public class NoMoneyStateTests
    {
        private StateContext _context;
        private ProductInfoRepository _productInfoRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _productInfoRepository = new InMemoryProductInfoRepository();
            _context = new VendingMachine(_productInfoRepository);
        }

        [TestMethod]
        public void NoMoneyState_WhenRefund_NoMoneyRefunded()
        {
            var state = new NoMoneyState(_context, new List<Coin>(), new List<Coin>(), _productInfoRepository);
            state.Refund(0, 0);

            CollectionAssert.AreEqual(new List<Coin>(), state.ReturnTray.ToList());
        }

        [TestMethod]
        public void NoMoneyState_WhenProductSelected_MoveToPriceState()
        {
            var vendingMachine = new VendingMachine(new InMemoryProductInfoRepository());
            vendingMachine.Dispense("candy");

            Assert.IsInstanceOfType(vendingMachine.State, typeof(PriceState));
        }
    }
}
