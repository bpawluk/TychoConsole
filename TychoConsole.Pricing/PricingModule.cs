using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Tycho.Modules;
using Tycho.Persistence.EFCore;
using TychoConsole.Pricing.Contract.Incoming.Events;
using TychoConsole.Pricing.Contract.Outgoing.Events;
using TychoConsole.Pricing.Messaging.Handlers;
using TychoConsole.Pricing.Persistence;

namespace TychoConsole.Pricing;

public class PricingModule : TychoModule
{
    protected override void DefineContract(IModuleContract module) { }

    protected override void DefineEvents(IModuleEvents module)
    {
        module.Handles<StockLevelChanged, StockLevelChangedHandler>();

        module.Routes<PriceChanged>()
              .Exposes();
    }

    protected override void IncludeModules(IModuleStructure module) { }

    protected override void RegisterServices(IServiceCollection module)
    {
        module.AddTychoPersistence<PricingDbContext>();
    }

    protected override async Task Startup(IServiceProvider app)
    {
        using var context = app.GetRequiredService<PricingDbContext>();
        await context.InitDatabase();
    }
}