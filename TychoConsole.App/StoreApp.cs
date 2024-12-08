using Microsoft.Extensions.DependencyInjection;
using Tycho.Apps;
using TychoConsole.App.Contract.Incoming.Requests;
using TychoConsole.App.Messaging.Handlers;
using TychoConsole.Catalog;
using TychoConsole.Inventory;
using TychoConsole.Pricing;
using static TychoConsole.App.Messaging.Mappers.EventMapper;
using CatalogIn = TychoConsole.Catalog.Contract.Incoming;
using InventoryOut = TychoConsole.Inventory.Contract.Outgoing;
using PricingIn = TychoConsole.Pricing.Contract.Incoming;
using PricingOut = TychoConsole.Pricing.Contract.Outgoing;

namespace TychoConsole.App;

public sealed class StoreApp : TychoApp
{
    protected override void DefineContract(IAppContract app)
    {
        app.Handles<BuyProduct, BuyProductHandler>();

        app.Forwards<CatalogIn.Requests.GetProducts, CatalogIn.Requests.GetProducts.Response, CatalogModule>()
           .Forwards<CatalogIn.Requests.FindProduct, CatalogIn.Requests.FindProduct.Response, CatalogModule>();
    }

    protected override void DefineEvents(IAppEvents app)
    {
        app.Routes<InventoryOut.Events.StockLevelChanged>()
           .ForwardsAs<CatalogIn.Events.StockLevelChanged, CatalogModule>(MapToCatalog)
           .ForwardsAs<PricingIn.Events.StockLevelChanged, PricingModule>(MapToPricing);

        app.Routes<PricingOut.Events.PriceChanged>()
           .ForwardsAs<CatalogIn.Events.PriceChanged, CatalogModule>(MapToCatalog);
    }

    protected override void IncludeModules(IAppStructure app)
    {
        app.Uses<CatalogModule>()
           .Uses<InventoryModule>()
           .Uses<PricingModule>();
    }

    protected override void RegisterServices(IServiceCollection app) { }
}
