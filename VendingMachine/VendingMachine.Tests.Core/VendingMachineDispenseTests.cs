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
        private VendingMachine _vendingMachine;

        [TestInitialize]
        public void TestInitialize()
        {
            _vendingMachine = new VendingMachine();
        }

        [TestMethod]
        public void VendingMachine_GivenNoCoins_DisplayPrice()
        {
            _vendingMachine.Dispense("soda");

            Assert.AreEqual("PRICE: $1.00", _vendingMachine.GetDisplayText());
        }

        [TestMethod]
        public void VendingMachine_GivenADollarAndAskedForSoda_DisplayThankYou()
        {
            InsertCoins(_vendingMachine, Coin.Quarter, 4);
            _vendingMachine.Dispense("soda");

            Assert.AreEqual("THANK YOU!", _vendingMachine.GetDisplayText());
        }

        [TestMethod]
        public void VendingMachine_GivenSomeCoinsButNotEnough_DisplayPrice()
        {
            _vendingMachine.Accept(Coin.Dime);

            _vendingMachine.Dispense("soda");

            Assert.AreEqual("PRICE: $1.00", _vendingMachine.GetDisplayText());
        }

        [TestMethod]
        public void VendingMachine_GivenTooManyCoins_DisplayThankYou()
        {
            InsertCoins(_vendingMachine, Coin.Quarter, 5);

            _vendingMachine.Dispense("soda");

            Assert.AreEqual("THANK YOU!", _vendingMachine.GetDisplayText());
        }

        [TestMethod]
        public void VendingMachine_GivenEnoughCoinsAndAskedForSoda_Dispense()
        {
            InsertCoins(_vendingMachine, Coin.Quarter, 5);
            _vendingMachine.Dispense("soda");

            Assert.AreEqual("soda", _vendingMachine.Output.First());
        }

        [TestMethod]
        public void VendingMachine_AfterDispensing_CoinsAreReturned()
        {
            // The thank you message should only show once. 
            // Be sure to return any extra coins and set us back to base state

            InsertCoins(_vendingMachine, Coin.Quarter, 6);
            _vendingMachine.Dispense("soda");

            // Force state change.
            _vendingMachine.GetDisplayText();

            var expected = Enumerable.Repeat((int) Coin.Quarter, 2).ToList();
            CollectionAssert.AreEqual(expected, _vendingMachine.ReturnTray.Select(c => (int)c).ToList());

            Assert.AreEqual("INSERT COIN", _vendingMachine.GetDisplayText());
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
