using Microsoft.Extensions.DependencyInjection;
using Tycho.Modules;
using TychoConsole.Pricing.Core.Abstractions;
using TychoConsole.Pricing.Core;
using TychoConsole.Pricing.Persistence;
using TychoConsole.Pricing.Contract.Incoming.Requests;
using TychoConsole.Pricing.Messaging.Handlers;
using TychoConsole.Pricing.Contract.Outgoing.Events;
using TychoConsole.Pricing.Contract.Incoming.Events;

namespace TychoConsole.Pricing;

public class PricingModule : TychoModule
{
    protected override void DefineContract(IModuleContract module) 
    {
        module.Handles<GetPrice, decimal, GetPriceHandler>();
    }

    protected override void IncludeModules(IModuleStructure module) { }

    protected override void MapEvents(IModuleEvents module)
    {
        module.Handles<StockLevelChanged, StockLevelChangedHandler>();

        module.Routes<PriceChanged>()
              .Exposes();
    }

    protected override void RegisterServices(IServiceCollection module)
    {
        module.AddTransient<IPricingStrategy, PricingStrategy>()
              .AddSingleton<IPricesRepository, PricesRepository>();
    }
}