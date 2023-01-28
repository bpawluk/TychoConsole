namespace Pricing.Persistence;

internal interface IPricesRepository
{
    decimal GetPriceByProductId(string productId);
    void SetPrice(string productId, decimal price);
}
