namespace TychoSample.App.Contract;

internal class Mapper
{
    public static Catalog.Contract.PriceChangedEvent MapToCatalog(Pricing.Contract.PriceChangedEvent eventData)
    {
        return new(eventData.ProductId, eventData.OldPrice, eventData.NewPrice);
    }

    public static Pricing.Contract.StockLevelChangedEvent MapToPricing(Inventory.Contract.StockLevelChangedEvent eventData)
    {
        return new(eventData.ProductId, eventData.PreviousLevel, eventData.CurrentLevel);
    }

    public static Catalog.Contract.StockLevelChangedEvent MapToCatalog(Inventory.Contract.StockLevelChangedEvent eventData)
    {
        return new(eventData.ProductId, eventData.PreviousLevel, eventData.CurrentLevel);
    }
}
