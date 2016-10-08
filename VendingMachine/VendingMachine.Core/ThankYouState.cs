using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;using Vending.Core;

namespace Vending.Core
{
    public class ThankYouState : VendingMachineState
    {
        public string Display()
        {
            return "THANK YOU!";
        }
    }
}
