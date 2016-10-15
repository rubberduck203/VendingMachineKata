using Vending.Core;

namespace Vending.Tests.Core
{
    public class FakeProductInfoRepository : ProductInfoRepository
    {
        //Properties so we can inject data into the fake
        public int QuantityAvailable { get; set; }

        public int Price { get; set; } = 65;

        // ProductInfoRepository implementation
        public int? GetPrice(string sku)
        {
            return Price;
        }

        public int GetQuantityAvailable(string sku)
        {
            return QuantityAvailable;
        }
    }
}