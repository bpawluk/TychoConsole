﻿using TychoConsole.Pricing.Core.Abstractions;

namespace TychoConsole.Pricing.Core;

internal class PricingStrategy(IPricesRepository pricesRepository) : IPricingStrategy
{
    private const decimal AVAILABILITY_ADJUSTMENT_FACTOR = 0.1M;

    private readonly IPricesRepository _priceRepository = pricesRepository;

    public void AdjustForAvailability(string productId, int previousStockLevel, int currentStockLevel)
    {
        var currentPrice = _priceRepository.GetPriceByProductId(productId);
        var availabilityAdjustment =
            AVAILABILITY_ADJUSTMENT_FACTOR * (previousStockLevel - currentStockLevel)
            / (previousStockLevel + currentStockLevel);
        var newPrice = currentPrice + currentPrice * availabilityAdjustment;
        _priceRepository.SetPrice(productId, newPrice);
    }
}