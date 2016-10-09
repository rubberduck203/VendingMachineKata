using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vending.Core;

namespace Vending.Tests.Core
{
    [TestClass]
    public class RefundCalculatorTests
    {
        private RefundCalculator _refunder;

        [TestInitialize]
        public void TestInitialize()
        {
            _refunder = new RefundCalculator();
        }

        [TestMethod]
        public void RefundCalculator_ZeroBalance_ReturnsZero()
        {
            var actual = _refunder.CalculateRefund(50, 50);
            AssertRefund(actual, nickels: 0, dimes:0, quarters:0);
        }

        [TestMethod]
        public void RefundCalculator_Price70_Given75_RefundANickel()
        {
            var actual = _refunder.CalculateRefund(70, 75);
            AssertRefund(actual, nickels:1, dimes:0, quarters:0);
        }

        [TestMethod]
        public void RefundCalculator_Price65_Given75_RefundADime()
        {
            var actual = _refunder.CalculateRefund(65, 75);
            AssertRefund(actual, nickels: 0, dimes: 1, quarters: 0);
        }

        [TestMethod]
        public void RefundCalculator_Price60_Given75_RefundADimeAndNickel()
        {
            var actual = _refunder.CalculateRefund(60, 75);
            AssertRefund(actual, nickels:1, dimes:1, quarters:0);
        }

        [TestMethod]
        public void RefundCalculator_Price30_Given50_RefundTwoDimes()
        {
            var actual = _refunder.CalculateRefund(30, 50);
            AssertRefund(actual, nickels:0, dimes:2, quarters:0);
        }

        [TestMethod]
        public void RefundCalculator_Price30_Given55_RefundAQuarter()
        {
            var actual = _refunder.CalculateRefund(30, 55);
            AssertRefund(actual, nickels:0, dimes:0, quarters:1);
        }

        [TestMethod]
        public void RefundCalculator_Price50_Given80_Refund3Dimes()
        {
            var acutal = _refunder.CalculateRefund(50, 80);
            AssertRefund(acutal, nickels:0, dimes:3, quarters:0);

            /* The test above is acceptable, but the one below would be better. */
            //AssertRefund(acutal, nickels:1, dimes:0, quarters:1);
        }

        private static void AssertRefund(IDictionary<Coin, int> actual, int nickels, int dimes, int quarters)
        {
            Assert.AreEqual(nickels, actual[Coin.Nickel]);
            Assert.AreEqual(dimes, actual[Coin.Dime]);
            Assert.AreEqual(quarters, actual[Coin.Quarter]);
        }
    }
}
