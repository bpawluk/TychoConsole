using System;
using System.Collections.Immutable;
using Microsoft.Extensions.DependencyInjection;
using Tycho.Apps;
using TychoConsole.App.Contract.Incoming.Requests;
using TychoConsole.App.Messaging.Handlers;
using TychoConsole.App.Messaging.Mappers;
using TychoConsole.Catalog;
using TychoConsole.Catalog.Contract.Entities;
using TychoConsole.Catalog.Contract.Incoming.Requests;
using TychoConsole.Inventory;
using TychoConsole.Pricing;
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

        app.Forwards<GetProducts, IImmutableList<Product>, CatalogModule>()
           .Forwards<FindProduct, Product, CatalogModule>();
    }

    protected override void IncludeModules(IAppStructure app)
    {
        app.Uses<CatalogModule>()
           .Uses<InventoryModule>()
           .Uses<PricingModule>();
    }

    protected override void MapEvents(IAppEvents app)
    {
        app.Routes<InventoryOut.Events.StockLevelChanged>()
           .ForwardsAs<PricingIn.Events.StockLevelChanged, PricingModule>(EventMapper.MapToPricing)
           .ForwardsAs<CatalogIn.Events.StockLevelChanged, CatalogModule>(EventMapper.MapToCatalog);

        app.Routes<PricingOut.Events.PriceChanged>()
           .ForwardsAs<CatalogIn.Events.PriceChanged, CatalogModule>(EventMapper.MapToCatalog);
    }

    protected override void RegisterServices(IServiceCollection app) { }
}
