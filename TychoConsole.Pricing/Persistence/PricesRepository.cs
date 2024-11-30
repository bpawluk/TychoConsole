using System;
using System.Collections.Generic;
using TychoConsole.Pricing.Core.Abstractions;

namespace TychoConsole.Pricing.Persistence;

internal class PricesRepository : IPricesRepository
{
    private readonly Dictionary<string, decimal> _pricesData = new()
    {
        ["product-01"] = 10,
        ["product-02"] = 25,
        ["product-03"] = 50,
    };

    public decimal GetPriceByProductId(string productId)
    {
        if (_pricesData.ContainsKey(productId))
        {
            return _pricesData[productId];
        }
        throw new ArgumentException($"There is no price data for product {productId}");
    }

    public void SetPrice(string productId, decimal price)
    {
        var oldPrice = _pricesData.ContainsKey(productId) ? _pricesData[productId] : default;
        _pricesData[productId] = price;
        //_thisModule.Publish<PriceChanged>(new(productId, oldPrice, price));
    }
}