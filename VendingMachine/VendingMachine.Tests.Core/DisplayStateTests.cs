using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vending.Core;
using Vending.Core.States;

namespace Vending.Tests.Core
{
    [TestClass]
    public class DisplayStateTests
    {
        private StateContext _context;
        private ProductInfoRepository _productInfoRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _productInfoRepository = new InMemoryProductInfoRepository();
            _context = new VendingMachine(_productInfoRepository);
        }

        [TestMethod]
        public void PriceState_Soda_Displays_OneDollar()
        {
            VendingMachineState state = new PriceState(_context, new List<Coin>(), new List<Coin>(), 100);
            Assert.AreEqual("PRICE: $1.00", state.Display());
        }

        [TestMethod]
        public void InsertCoinState_Displays_InsertCoin()
        {
            VendingMachineState state = new NoMoneyState(_context, new List<Coin>(), new List<Coin>(), _productInfoRepository);
            Assert.AreEqual("INSERT COIN", state.Display());
        }
    }
}
