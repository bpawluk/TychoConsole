using Microsoft.Extensions.DependencyInjection;
using Tycho.Modules;
using TychoConsole.Inventory.Contract.Incoming.Requests;
using TychoConsole.Inventory.Contract.Outgoing.Events;
using TychoConsole.Inventory.Core.Abstraction;
using TychoConsole.Inventory.Messaging.Handlers;
using TychoConsole.Inventory.Persistence;

namespace TychoConsole.Inventory;

public class InventoryModule : TychoModule
{
    protected override void DefineContract(IModuleContract module)
    {
        module.Handles<ReserveProduct, ReserveProductHandler>();
    }

    protected override void IncludeModules(IModuleStructure module) { }

    protected override void MapEvents(IModuleEvents module)
    {
        module.Routes<StockLevelChanged>()
              .Exposes();
    }

    protected override void RegisterServices(IServiceCollection module)
    {
        module.AddSingleton<IStockLevelsRepository, StockLevelsRepository>();
    }
}