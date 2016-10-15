using System.Collections.Generic;

namespace Vending.Core.States
{
    public abstract class VendingMachineState
    {
        private readonly List<Coin> _returnTray = new List<Coin>();
        public IEnumerable<Coin> ReturnTray => _returnTray;
        public abstract string Display();

        public  int CurrentTotal(IEnumerable<Coin> coins)
        {
            var counts = new Dictionary<Coin, int>()
            {
                {Coin.Nickel, 0},
                {Coin.Dime, 0},
                {Coin.Quarter, 0}
            };

            foreach (var coin in coins)
            {
                counts[coin]++;
            }

            var total = 0;
            foreach (var coinCount in counts)
            {
                total += (coinCount.Value * coinCount.Key.Value());
            }

            return total;
        }

        public virtual void Refund()
        {
            
        }
    }
}
