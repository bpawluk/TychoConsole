using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Tycho.Modules;
using Tycho.Persistence.EFCore;
using TychoConsole.Catalog.Contract.Incoming.Events;
using TychoConsole.Catalog.Contract.Incoming.Requests;
using TychoConsole.Catalog.Messaging.Handlers;
using TychoConsole.Catalog.Persistence;

namespace TychoConsole.Catalog;

public class CatalogModule : TychoModule
{
    protected override void DefineContract(IModuleContract module)
    {
        module.Handles<FindProduct, FindProduct.Response, FindProductHandler>()
              .Handles<GetProducts, GetProducts.Response, GetProductsHandler>();
    }

    protected override void DefineEvents(IModuleEvents module)
    {
        module.Handles<PriceChanged, PriceChangedHandler>()
              .Handles<StockLevelChanged, StockLevelChangedHandler>();
    }

    protected override void IncludeModules(IModuleStructure module) { }

    protected override void RegisterServices(IServiceCollection module)
    {
        module.AddTychoPersistence<CatalogDbContext>();
    }

    protected override async Task Startup(IServiceProvider app)
    {
        using var context = app.GetRequiredService<CatalogDbContext>();
        await context.InitDatabase();
    }
}