using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vending.Core;

namespace Vending.Tests.Core
{
    [TestClass]
    public class RefundCalculatorTests
    {
        [TestMethod]
        public void RefundCalculator_ZeroBalance_ReturnsZero()
        {
            var refunder = new RefundCalculator();
            var actual = refunder.CalculateRefund(50, 50);

            Assert.AreEqual(0, actual[Coin.Nickel]);
            Assert.AreEqual(0, actual[Coin.Dime]);
            Assert.AreEqual(0, actual[Coin.Quarter]);
        }

        [TestMethod]
        public void RefundCalculator_Price70_Given75_RefundANickel()
        {
            var refunder = new RefundCalculator();
            var actual = refunder.CalculateRefund(70, 75);

            Assert.AreEqual(1, actual[Coin.Nickel]);
            Assert.AreEqual(0, actual[Coin.Dime]);
            Assert.AreEqual(0, actual[Coin.Quarter]);
        }

        [TestMethod]
        public void RefundCalculator_Price65_Given75_RefundADime()
        {
            var refunder = new RefundCalculator();
            var actual = refunder.CalculateRefund(65, 75);

            Assert.AreEqual(0, actual[Coin.Nickel]);
            Assert.AreEqual(1, actual[Coin.Dime]);
            Assert.AreEqual(0, actual[Coin.Quarter]);
        }
    }
}
