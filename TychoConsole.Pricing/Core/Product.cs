namespace TychoConsole.Pricing.Core;

internal class Product(int id, decimal price, int stockLevel)
{
    public int Id { get; private set; } = id;

    public decimal Price { get; private set; } = price;

    public int StockLevel { get; private set; } = stockLevel;

    public void ApplyNewStockLevel(int newStockLevel)
    {
        var previousStockLevel = StockLevel;
        StockLevel = newStockLevel;
        AdjustPrice(previousStockLevel);
    }

    private void AdjustPrice(int previousStockLevel)
    {
        var availabilityAdjustment = 0.5M * (previousStockLevel - StockLevel) / (previousStockLevel + StockLevel);
        Price += Price * availabilityAdjustment;
    }
}