using System;
using System.Threading;
using System.Threading.Tasks;
using Tycho.Events;
using Tycho.Persistence.EFCore;
using TychoConsole.Pricing.Contract.Incoming.Events;
using TychoConsole.Pricing.Contract.Outgoing.Events;
using TychoConsole.Pricing.Core;

namespace TychoConsole.Pricing.Messaging.Handlers;

internal class StockLevelChangedHandler(IUnitOfWork unitOfWork) : IEventHandler<StockLevelChanged>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(StockLevelChanged eventData, CancellationToken cancellationToken = default)
    {
        Console.WriteLine("> Pricing.StockLevelChangedHandler processing started");

        var product = await _unitOfWork
            .Set<Product>()
            .FindAsync([eventData.ProductId], cancellationToken);

        if (product is null)
        {
            throw new InvalidOperationException($"Failed to set new Stock Level for a Product with ID {eventData.ProductId}");
        }

        product.ApplyNewStockLevel(eventData.NewStockLevel);
        await _unitOfWork.Publish(new PriceChanged(product.Id, product.Price));

        await _unitOfWork.SaveChanges(cancellationToken);
        Console.WriteLine("> Pricing.StockLevelChangedHandler processing finished");
    }
}