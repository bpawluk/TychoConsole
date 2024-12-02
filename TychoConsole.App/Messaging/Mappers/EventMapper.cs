using CatalogIn = TychoConsole.Catalog.Contract.Incoming.Events;
using InventoryOut = TychoConsole.Inventory.Contract.Outgoing.Events;
using PricingIn = TychoConsole.Pricing.Contract.Incoming.Events;
using PricingOut = TychoConsole.Pricing.Contract.Outgoing.Events;

namespace TychoConsole.App.Messaging.Mappers;

internal class EventMapper
{
    public static CatalogIn.PriceChanged MapToCatalog(PricingOut.PriceChanged eventData)
    {
        return new(eventData.ProductId, eventData.NewPrice);
    }

    public static CatalogIn.StockLevelChanged MapToCatalog(InventoryOut.StockLevelChanged eventData)
    {
        return new(eventData.ItemId, eventData.NewStockLevel);
    }

    public static PricingIn.StockLevelChanged MapToPricing(InventoryOut.StockLevelChanged eventData)
    {
        return new(eventData.ItemId, eventData.NewStockLevel);
    }
}