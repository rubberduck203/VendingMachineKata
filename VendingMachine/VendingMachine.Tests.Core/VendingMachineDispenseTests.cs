using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vending.Core;

namespace Vending.Tests.Core
{
    [TestClass]
    public class VendingMachineDispenseTests
    {
        [TestMethod]
        public void VendingMachine_GivenNoCoins_DisplayPrice()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.Dispense("soda");

            Assert.AreEqual("PRICE: $1.00", vendingMachine.GetDisplayText());
        }
    }
}
