using System.Collections.Immutable;
using Microsoft.Extensions.DependencyInjection;
using Tycho.Modules;
using TychoConsole.Catalog.Contract.Entities;
using TychoConsole.Catalog.Contract.Incoming.Events;
using TychoConsole.Catalog.Contract.Incoming.Requests;
using TychoConsole.Catalog.Core.Abstraction;
using TychoConsole.Catalog.Messaging.Handlers;
using TychoConsole.Catalog.Persistence;

namespace TychoConsole.Catalog;

public class CatalogModule : TychoModule
{
    protected override void DefineContract(IModuleContract module)
    {
        module.Handles<FindProduct, Product, FindProductHandler>()
              .Handles<GetProducts, IImmutableList<Product>, GetProductsHandler>();
    }

    protected override void IncludeModules(IModuleStructure module) { }

    protected override void MapEvents(IModuleEvents module)
    {
        module.Handles<PriceChanged, PriceChangedHandler>()
              .Handles<StockLevelChanged, StockLevelChangedHandler>();
    }

    protected override void RegisterServices(IServiceCollection module)
    {
        module.AddSingleton<IProductsRepository, ProductsRepository>();
    }
}