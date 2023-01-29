using Microsoft.Extensions.DependencyInjection;
using System;
using Tycho;
using Tycho.Contract;
using Tycho.Structure;
using TychoSample.Inventory.Contract;
using TychoSample.Inventory.Persistence;

namespace TychoSample.Inventory;

public class InventoryModule : TychoModule
{
    protected override void DeclareIncomingMessages(IInboxDefinition module, IServiceProvider services)
    {
        module.Executes<ReserveProductCommand>(commandData => 
        {
            services.GetService<IStockLevelsRepository>()!
                    .ReserveProduct(commandData.ProductId, commandData.Amount);
        });
    }

    protected override void DeclareOutgoingMessages(IOutboxDefinition module, IServiceProvider services)
    {
        module.Publishes<StockLevelChangedEvent>();
    }

    protected override void IncludeSubmodules(ISubstructureDefinition submodules, IServiceProvider services) { }

    protected override void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<IStockLevelsRepository, StockLevelsRepository>();
    }
}
