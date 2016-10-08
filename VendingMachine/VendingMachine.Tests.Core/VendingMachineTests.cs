using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vending.Core;

namespace Vending.Tests.Core
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        public void VendingMachine_OnStartUp_Displays_InsertCoin()
        {
            var vendingMachine = new VendingMachine();
        }
    }
}
