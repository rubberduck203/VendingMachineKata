using System.Collections.Generic;

namespace Vending.Core
{
    public enum Coin
    {
        Penny,
        Nickel,
        Dime,
        Quarter,
        FiftyCentPiece,
        Dollar
    }

    public static class CoinExtensions
    {
        public static byte Value(this Coin coin)
        {
            switch (coin)
            {
                case Coin.Nickel:
                    return 5;
                case Coin.Dime:
                    return 10;
                case Coin.Quarter:
                    return 25;
                default:
                    return 0;
            }
        }
    }
}