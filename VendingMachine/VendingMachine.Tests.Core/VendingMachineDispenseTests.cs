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

        [TestMethod]
        public void VendingMachine_GivenADollarAndAskedForSoda_DisplayThankYou()
        {
            var vendingMachine = new VendingMachine();

            InsertCoins(vendingMachine, Coin.Quarter, 4);
            vendingMachine.Dispense("soda");

            Assert.AreEqual("THANK YOU!", vendingMachine.GetDisplayText());
        }

        [TestMethod]
        public void VendingMachine_GivenSomeCoinsButNotEnough_DisplayPrice()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.Accept(Coin.Dime);

            vendingMachine.Dispense("soda");

            Assert.AreEqual("PRICE: $1.00", vendingMachine.GetDisplayText());
        }

        [TestMethod]
        public void VendingMachine_GivenTooManyCoins_DisplayThankYou()
        {
            var vendingMachine = new VendingMachine();

            InsertCoins(vendingMachine, Coin.Quarter, 5);

            vendingMachine.Dispense("soda");

            Assert.AreEqual("THANK YOU!", vendingMachine.GetDisplayText());
        }

        private void InsertCoins(VendingMachine machine, Coin coin, int count)
        {
            for (int i = 0; i < count; i++)
            {
                machine.Accept(coin);
            }
        }
    }
}
