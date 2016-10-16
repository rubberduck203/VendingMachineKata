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
        public void RefundCalculator_WhenPrice30_And2DimesInVault_CanMakeChange()
        {
            var calculator = new RefundCalculator();
            var vault = Enumerable.Repeat(Coin.Dime, 2);

            Assert.IsTrue(calculator.CanMakeChange(30, vault));
        }

        [TestMethod]
        public void RefundCalculator_WhenNoCoinsInVault_ExactChangeOnly()
        {
            var calculator = new RefundCalculator();
            Assert.IsFalse(calculator.CanMakeChange(30, Enumerable.Empty<Coin>()));
        }

        [TestMethod]
        public void RefundCalculator_WhenPrice30_And4NickelsInVault_ExactChangeOnly()
        {
            /* 
             * Even though we could make change with 4 Nickels, our refund calculator
             * currently won't, even if it has 4 nickels, but not 2 dimes.
             */

            var calculator = new RefundCalculator();
            Assert.IsFalse(calculator.CanMakeChange(30, Enumerable.Repeat(Coin.Nickel, 4)));
        }

        [TestMethod]
        public void RefundCalculator_WhenPrice30_And1QuarterInVault_ExactChangeOnly()
        {
            var calculator = new RefundCalculator();
            Assert.IsFalse(calculator.CanMakeChange(30, new List<Coin>(1) { Coin.Quarter }));
        }

        [TestMethod]
        public void RefundCalculator_WhenPrice25_And1QuarterInVault_CanMakeChange()
        {
            var calculator = new RefundCalculator();
            Assert.IsTrue(calculator.CanMakeChange(25, new List<Coin>(1) { Coin.Quarter }));
        }
    }
}
