using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vending.Core;

namespace Vending.Tests.Core
{
    [TestClass]
    public class VendingMachineTests
    {
        private VendingMachine _vendingMachine;

        [TestInitialize]
        public void TestInitialize()
        {
            _vendingMachine = new VendingMachine();
        }

        [TestMethod]
        public void VendingMachine_OnStartUp_Displays_InsertCoin()
        {
            Assert.AreEqual("INSERT COIN", _vendingMachine.GetDisplayText());
        }

        [TestMethod]
        public void VendingMachine_GivenANickel_Displays_5()
        {
            _vendingMachine.Accept(Coin.Nickel);
            Assert.AreEqual("$0.05", _vendingMachine.GetDisplayText());
        }

        [TestMethod]
        public void VendingMachine_GivenTwoNickels_Displays_10()
        {
            _vendingMachine.Accept(Coin.Nickel);
            _vendingMachine.Accept(Coin.Nickel);
            Assert.AreEqual("$0.10", _vendingMachine.GetDisplayText());
        }

        [TestMethod]
        public void VendingMachine_GivenANickelAndADime_Displays_15()
        {
            _vendingMachine.Accept(Coin.Nickel);
            _vendingMachine.Accept(Coin.Dime);
            Assert.AreEqual("$0.15", _vendingMachine.GetDisplayText());
        }

        [TestMethod]
        public void VendingMachine_GivenAQuarter_Displays_25()
        {
            _vendingMachine.Accept(Coin.Quarter);
            Assert.AreEqual("$0.25", _vendingMachine.GetDisplayText());
        }

        [TestMethod]
        public void VendingMachine_GivenAQuarterAndADime_Displays_35()
        {
            _vendingMachine.Accept(Coin.Quarter);
            _vendingMachine.Accept(Coin.Dime);
            Assert.AreEqual("$0.35", _vendingMachine.GetDisplayText());
        }

        [TestMethod]
        public void VendingMachine_Given4QuartersAnd2DimesAnd3Nickels_Displays_135()
        {
            for (var i = 0; i < 4; i++)
            {
                _vendingMachine.Accept(Coin.Quarter);
            }

            for (var i = 0; i < 2; i++)
            {
                _vendingMachine.Accept(Coin.Dime);
            }

            for (var i = 0; i < 3; i++)
            {
                _vendingMachine.Accept(Coin.Nickel);
            }

            Assert.AreEqual("$1.35", _vendingMachine.GetDisplayText());
        }

        [TestMethod]
        public void VendingMachine_GivenAPenny_Displays_InsertCoin()
        {
            _vendingMachine.Accept(Coin.Penny);
            Assert.AreEqual("INSERT COIN", _vendingMachine.GetDisplayText());
        }

        [TestMethod]
        public void VendingMachine_GivenAPenny_ReturnTrayContainsAPenny()
        {
            _vendingMachine.Accept(Coin.Penny);
            Assert.AreEqual(1, _vendingMachine.ReturnTray.Count(c => c == Coin.Penny));
        }

        [TestMethod]
        public void VendingMachine_GivenAFiftyCentPiece_Reject()
        {
            /*
             * note: There's a call out to the client to see if we should support these.
             *  For now, we need to treat these like pennies so we don't get exceptions.
             */

            _vendingMachine.Accept(Coin.FiftyCentPiece);
            Assert.AreEqual("INSERT COIN", _vendingMachine.GetDisplayText());
            Assert.AreEqual(1, _vendingMachine.ReturnTray.Count(c => c == Coin.FiftyCentPiece));
        }
    }
}
