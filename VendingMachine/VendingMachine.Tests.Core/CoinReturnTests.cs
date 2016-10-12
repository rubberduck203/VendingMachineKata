using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vending.Core;

namespace Vending.Tests.Core
{
    [TestClass]
    public class CoinReturnTests
    {
        [TestMethod]
        public void CoinReturn_WhenNoMoneyInCoinSlot_NoCoinsInReturn()
        {
            var vendingMachine = new VendingMachine(new InMemoryProductInfoRepository());
            vendingMachine.ReturnCoins();

            CollectionAssert.AreEqual(new List<Coin>(), vendingMachine.ReturnTray.ToList());
        }
    }
}
