﻿using System;
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

            AssertRefund(actual, nickels: 0, dimes:0, quarters:0);
        }

        [TestMethod]
        public void RefundCalculator_Price70_Given75_RefundANickel()
        {
            var refunder = new RefundCalculator();
            var actual = refunder.CalculateRefund(70, 75);

            AssertRefund(actual, nickels:1, dimes:0, quarters:0);
        }

        [TestMethod]
        public void RefundCalculator_Price65_Given75_RefundADime()
        {
            var refunder = new RefundCalculator();
            var actual = refunder.CalculateRefund(65, 75);

            AssertRefund(actual, nickels: 0, dimes: 1, quarters: 0);
        }

        [TestMethod]
        public void RefundCalculator_Price60_Given75_RefundADimeAndNickel()
        {
            var refunder = new RefundCalculator();
            var actual = refunder.CalculateRefund(60, 75);

            AssertRefund(actual, nickels:1, dimes:1, quarters:0);
        }

        private static void AssertRefund(IDictionary<Coin, int> actual, int nickels, int dimes, int quarters)
        {
            Assert.AreEqual(nickels, actual[Coin.Nickel]);
            Assert.AreEqual(dimes, actual[Coin.Dime]);
            Assert.AreEqual(quarters, actual[Coin.Quarter]);
        }
    }
}
