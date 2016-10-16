using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vending.Core;
using Vending.Core.States;

namespace Vending.Tests.Core
{
    [TestClass]
    public class ExactChangeOnlyTests
    {
        [TestMethod]
        public void ExactChangeOnly_WhenOnlyQuarters_ExactChangeOnly()
        {
            var productRepository = new FakeProductInfoRepository()
            {
                Price = 65,
                QuantityAvailable = 3
            };

            var vendingMachine = new VendingMachine(productRepository);
            vendingMachine.State.Vault.Clear();
            vendingMachine.State.Vault.AddRange(Enumerable.Repeat(Coin.Quarter, 4));

            Assert.AreEqual("EXACT CHANGE ONLY", vendingMachine.GetDisplayText());
        }

        [TestMethod]
        public void ExactChangeOnly_MachineStartsUpWithChange()
        {
            var vendingMachine = new VendingMachine(new InMemoryProductInfoRepository());
            Assert.AreEqual("INSERT COIN", vendingMachine.GetDisplayText());
        }

        [TestMethod]
        public void RefundCalculator_WhenNoCoinsInVault_ExactChangeOnly()
        {
            var calculator = new RefundCalculator();
            Assert.IsFalse(calculator.CanMakeChange(30, Enumerable.Empty<Coin>()));
        }

        [TestMethod]
        public void RefundCalculator_WhenLessThanThreeNickelsInVault_ExactChangeOnly()
        {
            var calculator = new RefundCalculator();
            Assert.IsFalse(calculator.CanMakeChange(0, Enumerable.Repeat(Coin.Nickel, 2)));
        }
    }
}
