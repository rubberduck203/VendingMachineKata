using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vending.Core;
using Vending.Core.States;

namespace Vending.Tests.Core
{
    [TestClass]
    public class NoMoneyStateTests
    {
        [TestMethod]
        public void NoMoneyState_WhenRefund_NoMoneyRefunded()
        {
            var state = new NoMoneyState(new List<Coin>());
            state.Refund(0, 0);

            CollectionAssert.AreEqual(new List<Coin>(), state.ReturnTray.ToList());
        }
    }
}
