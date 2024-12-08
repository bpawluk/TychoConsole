using System.Threading.Tasks;
using System;
using Microsoft.Extensions.DependencyInjection;
using Tycho.Modules;
using Tycho.Persistence.EFCore;
using TychoConsole.Inventory.Contract.Incoming.Requests;
using TychoConsole.Inventory.Contract.Outgoing.Events;
using TychoConsole.Inventory.Messaging.Handlers;
using TychoConsole.Inventory.Persistence;

namespace TychoConsole.Inventory;

public class InventoryModule : TychoModule
{
    protected override void DefineContract(IModuleContract module)
    {
        module.Handles<ReserveItem, ReserveItemHandler>();
    }

    protected override void DefineEvents(IModuleEvents module)
    {
        module.Routes<StockLevelChanged>()
              .Exposes();
    }

    protected override void IncludeModules(IModuleStructure module) { }

    protected override void RegisterServices(IServiceCollection module)
    {
        module.AddTychoPersistence<InventoryDbContext>();
    }

    protected override async Task Startup(IServiceProvider app)
    {
        using var context = app.GetRequiredService<InventoryDbContext>();
        await context.InitDatabase();
    }
}