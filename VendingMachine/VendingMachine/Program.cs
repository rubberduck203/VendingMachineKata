using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending.Core;

namespace Vending
{
    class Program
    {
        static void Main(string[] args)
        {
            // We'll use this simple console app to demo until the hardware is ready

            Console.WriteLine("Vending Machine!");
            Console.WriteLine();
            Console.WriteLine("[1] - Nickel");
            Console.WriteLine("[2] - Dime");
            Console.WriteLine("[3] - Quarter");
            Console.WriteLine();

            var vendingMachine = new VendingMachine(new InMemoryProductInfoRepository());

            Console.WriteLine(vendingMachine.GetDisplayText());

            while (true)
            {
                int input;
                if (Int32.TryParse(Console.ReadLine(), out input))
                {
                    vendingMachine.Accept((Coin)input);
                    Console.WriteLine(vendingMachine.GetDisplayText());
                }
            }
        }
    }
}
