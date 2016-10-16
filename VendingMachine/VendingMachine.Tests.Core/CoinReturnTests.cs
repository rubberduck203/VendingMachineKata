using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vending.Core;

namespace Vending.Tests.Core
{
    [TestClass]
    public class CoinReturnTests
    {
        private VendingMachine _vendingMachine;

        [TestInitialize]
        public void TestInitialize()
        {
            _vendingMachine = new VendingMachine(new InMemoryProductInfoRepository());
        }

        [TestMethod]
        public void CoinReturn_WhenNoMoneyInCoinSlot_NoCoinsInReturn()
        {
            _vendingMachine.ReturnCoins();

            CollectionAssert.AreEqual(new List<Coin>(), _vendingMachine.ReturnTray.ToList());
        }

        [TestMethod]
        public void CoinReturn_WhenACoinIsInserted_ACoinOfSameValueIsReturned()
        {
            _vendingMachine.Accept(Coin.Dime);

            _vendingMachine.ReturnCoins();

            CollectionAssert.AreEqual(new List<Coin>() { Coin.Dime }, _vendingMachine.ReturnTray.ToList());
        }

        [TestMethod]
        public void CoinReturn_WhenMultipleCoinsAreInserted_CoinsOfSameValueAreReturned()
        {
            var expected = new List<Coin>()
            {
                Coin.Dime,
                Coin.Quarter,
                Coin.Nickel,
                Coin.Dime
            };

            foreach (var coin in expected)
            {
                _vendingMachine.Accept(coin);
            }

            _vendingMachine.ReturnCoins();

            CollectionAssert.AreEqual(expected, _vendingMachine.ReturnTray.ToList());
        }

        [TestMethod]
        public void CoinReturn_WhenCoinsAreReturned_DisplaysInsertCoin()
        {
            _vendingMachine.Accept(Coin.Dime);
            _vendingMachine.ReturnCoins();

            Assert.AreEqual("INSERT COIN", _vendingMachine.GetDisplayText());
        }
    }
}
