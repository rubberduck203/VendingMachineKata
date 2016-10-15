using System.Collections.Generic;

namespace Vending.Core
{
    public class InMemoryProductInfoRepository : ProductInfoRepository
    {
        private static readonly Dictionary<string, ProductInfo> Info = new Dictionary<string, ProductInfo>()
        {
            {"soda", new ProductInfo() {Sku = "soda", Price = 100, QuantityOnHand = 10} },
            {"candy", new ProductInfo() {Sku = "candy", Price = 65, QuantityOnHand = 10 } },
            {"chips", new ProductInfo() {Sku = "chips", Price = 50, QuantityOnHand = 10 } }
        };

        public int? GetPrice(string sku)
        {
            ProductInfo product;
            if (Info.TryGetValue(sku, out product))
            {
                return product.Price;
            }

            return null;
        }

        public int GetQuantityAvailable(string sku)
        {
            ProductInfo product;
            if (Info.TryGetValue(sku, out product))
            {
                return product.QuantityOnHand;
            }

            return 0;
        }
    }

    public struct ProductInfo
    {
        public string Sku { get; set; }
        public int Price { get; set; }
        public int QuantityOnHand { get; set; }
    }
}