namespace Vending.Core
{
    public struct ProductInfo
    {
        public string Sku { get; set; }
        public int Price { get; set; }
        public int QuantityOnHand { get; set; }
    }
}