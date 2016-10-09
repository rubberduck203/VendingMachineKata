using System;
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
        }
    }
}
