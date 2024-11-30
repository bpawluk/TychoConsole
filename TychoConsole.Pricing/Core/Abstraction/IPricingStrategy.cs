namespace TychoConsole.Pricing.Core.Abstractions;

internal interface IPricingStrategy
{
    void AdjustForAvailability(string productId, int previousStockLevel, int currentStockLevel);
}