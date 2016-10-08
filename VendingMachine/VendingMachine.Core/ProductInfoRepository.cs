namespace Vending.Core
{
    public interface ProductInfoRepository
    {
        /// <summary>
        /// Retrieves the price of a sku in cents
        /// </summary>
        int? GetPrice(string sku);
    }
}