using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Tycho;
using Tycho.Contract;
using Tycho.Structure;
using TychoSample.Catalog.Contract;
using TychoSample.Catalog.Contract.Model;
using TychoSample.Catalog.Persistence;

namespace TychoSample.Catalog;

public class CatalogModule : TychoModule
{
    protected override void DeclareIncomingMessages(IInboxDefinition module, IServiceProvider services)
    {
        var repository = services.GetService<IProductsRepository>()!;

        module.RespondsTo<GetProductsQuery, IEnumerable<Product>>(q => repository.GetProducts())
              .RespondsTo<FindProductQuery, Product>(q => repository.FindProduct(q.ProductName)!)
              .SubscribesTo<PriceChangedEvent>(e => repository.UpdatePrice(e.ProductId, e.NewPrice))
              .SubscribesTo<StockLevelChangedEvent>(e => repository.UpdateStockLevel(e.ProductId, e.NewLevel));
    }

    protected override void DeclareOutgoingMessages(IOutboxDefinition module, IServiceProvider services) { }

    protected override void IncludeSubmodules(ISubstructureDefinition submodules, IServiceProvider services) { }

    protected override void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<IProductsRepository, ProductsRepository>();
    }
}
