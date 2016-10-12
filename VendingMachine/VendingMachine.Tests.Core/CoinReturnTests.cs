using System;
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
        }
    }
}
