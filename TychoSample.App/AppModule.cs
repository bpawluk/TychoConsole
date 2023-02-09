using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Tycho;
using Tycho.Contract;
using Tycho.Structure;
using TychoSample.App.Contract;
using TychoSample.App.Contract.Handlers;
using TychoSample.Catalog;
using TychoSample.Catalog.Contract;
using TychoSample.Catalog.Contract.Model;
using TychoSample.Inventory;
using TychoSample.Pricing;
using static TychoSample.App.Contract.Mapper;

namespace TychoSample.App;

public sealed class AppModule : TychoModule
{
    protected override void DeclareIncomingMessages(IInboxDefinition module, IServiceProvider services)
    {
        module.Executes<BuyProductCommand, BuyProductCommandHandler>()
              .Forwards<GetProductsQuery, IEnumerable<Product>, CatalogModule>()
              .Forwards<FindProductQuery, Product, CatalogModule>();
    }

    protected override void DeclareOutgoingMessages(IOutboxDefinition module, IServiceProvider services) { }

    protected override void IncludeSubmodules(ISubstructureDefinition module, IServiceProvider services)
    {
        module.AddSubmodule<CatalogModule>();

        module.AddSubmodule<InventoryModule>((IOutboxConsumer thisConsumer) =>
        {
            thisConsumer.PassOn<Inventory.Contract.StockLevelChangedEvent, Pricing.Contract.StockLevelChangedEvent, PricingModule>(
                MapToPricing);

            thisConsumer.PassOn<Inventory.Contract.StockLevelChangedEvent, Catalog.Contract.StockLevelChangedEvent, CatalogModule>(
                MapToCatalog);
        });

        module.AddSubmodule<PricingModule>((IOutboxConsumer thisConsumer) =>
        {
            thisConsumer.PassOn<Pricing.Contract.PriceChangedEvent, Catalog.Contract.PriceChangedEvent, CatalogModule>(
                MapToCatalog);
        });
    }

    protected override void RegisterServices(IServiceCollection services, IConfiguration configuration) { }
}
