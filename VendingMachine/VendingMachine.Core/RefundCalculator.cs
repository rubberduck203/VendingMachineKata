using System.Collections.Generic;
using System.Linq;

namespace Vending.Core
{
    public class RefundCalculator
    {
        public IDictionary<Coin, int> CalculateRefund(int priceInCents, int paidInCents)
        {
            var refund = new Dictionary<Coin, int>()
            {
                {Coin.Nickel, 0},
                {Coin.Dime, 0},
                {Coin.Quarter, 0}
            };

            var refundValue = paidInCents - priceInCents;

            if (refundValue <= 0)
            {
                return refund;
            }

            var nickels = refundValue / Coin.Nickel.Value();

            const int nickelsPerQuarter = 5;
            int quarters;
            nickels = ReduceNickels(nickels, nickelsPerQuarter, out quarters);

            const int nickelsPerDime = 2;
            int dimes;
            nickels = ReduceNickels(nickels, nickelsPerDime, out dimes);

            refund[Coin.Nickel] = nickels;
            refund[Coin.Dime] = dimes;
            refund[Coin.Quarter] = quarters;

            return refund;
        }

        private static int ReduceNickels(int nickels, int nickelsPerCoin, out int coinCount)
        {
            coinCount = 0;
            if (nickels >= nickelsPerCoin)
            {
                coinCount = nickels / nickelsPerCoin;
                nickels -= (coinCount * nickelsPerCoin);
            }
            return nickels;
        }

        public bool CanMakeChange(IEnumerable<Coin> vault)
        {
            /*
             * So, I could spend ages working out an algorithm to work this problem out
             * for the generic case, or we can hard code a suboptimal solution that lets me 
             * ship today.
             * 
             * TODO: Replace with smarter algorithm.
             * Perhaps create a fallback algorithm for the CalculateRefund method, 
             * or change it entirely to use the Greedy algorithm.
             * 
             * See Issue #
             */

            var coinCounts = new Dictionary<Coin, int>()
            {
                {Coin.Nickel, 0},
                {Coin.Dime, 0},
                {Coin.Quarter, 0}
            };

            foreach (var coin in vault)
            {
                switch (coin)
                {
                    case Coin.Nickel:
                    case Coin.Dime:
                    case Coin.Quarter:
                        coinCounts[coin]++;
                        break;
                    default:
                        //do nothing with unsupported coins
                        break;
                    
                }
            }

            foreach (var count in coinCounts)
            {
                if (count.Value < 5)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
