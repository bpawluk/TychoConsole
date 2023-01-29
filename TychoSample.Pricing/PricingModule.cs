using Microsoft.Extensions.DependencyInjection;
using System;
using Tycho;
using Tycho.Contract;
using Tycho.Structure;
using TychoSample.Pricing.Business;
using TychoSample.Pricing.Contract;
using TychoSample.Pricing.Persistence;

namespace TychoSample.Pricing;

public class PricingModule : TychoModule
{
    protected override void DeclareIncomingMessages(IInboxDefinition module, IServiceProvider services)
    {
        module.SubscribesTo<StockLevelChangedEvent>(eventData =>
        {
            services.GetService<IPricingStrategy>()!
                    .AdjustForAvailability(eventData.ProductId, eventData.OldLevel, eventData.NewLevel);
        });

        module.RespondsTo<GetPriceQuery, decimal>(queryData =>
        {
            return services.GetService<IPricesRepository>()!
                           .GetPriceByProductId(queryData.ProductId);
        });
    }

    protected override void DeclareOutgoingMessages(IOutboxDefinition module, IServiceProvider services)
    {
        module.Publishes<PriceChangedEvent>();
    }

    protected override void IncludeSubmodules(ISubstructureDefinition submodules, IServiceProvider services) { }

    protected override void RegisterServices(IServiceCollection services)
    {
        services.AddTransient<IPricingStrategy, PricingStrategy>()
                .AddSingleton<IPricesRepository, PricesRepository>();
    }
}
