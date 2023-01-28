using App.Contract;
using App.Handlers;
using Catalog;
using Catalog.Contract;
using Catalog.Model;
using Inventory;
using Microsoft.Extensions.DependencyInjection;
using Pricing;
using System;
using System.Collections.Generic;
using Tycho;
using Tycho.Contract;
using Tycho.Structure;
using static App.Contract.Mapper;

namespace App;

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

    protected override void RegisterServices(IServiceCollection services) { }
}
