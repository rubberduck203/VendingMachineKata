using System.Collections.Generic;

namespace Vending.Core
{
    public class InMemoryProductInfoRepository : ProductInfoRepository
    {
        private static readonly Dictionary<string, int> Info = new Dictionary<string, int>()
        {
            {"soda", 100},
            {"candy", 65},
            {"chips", 50}
        };

        public int? GetPrice(string sku)
        {
            int price;
            if (Info.TryGetValue(sku, out price))
            {
                return price;
            }

            return null;
        }
    }
}