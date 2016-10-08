using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vending.Core;

namespace Vending.Tests.Core
{
    [TestClass]
    public class PriceStateTests
    {
        [TestMethod]
        public void PriceState_Soda_Displays_OneDollar()
        {
            var state = new PriceState();
            Assert.AreEqual("PRICE: $1.00", state.Display());
        }
    }
}
