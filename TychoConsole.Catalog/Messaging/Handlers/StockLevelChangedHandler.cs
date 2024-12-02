using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Tycho.Events;
using Tycho.Persistence.EFCore;
using TychoConsole.Catalog.Contract.Incoming.Events;
using TychoConsole.Catalog.Core;

namespace TychoConsole.Catalog.Messaging.Handlers;

internal class StockLevelChangedHandler(IUnitOfWork unitOfWork) : IEventHandler<StockLevelChanged>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(StockLevelChanged eventData, CancellationToken cancellationToken)
    {
        Console.WriteLine("> Catalog.StockLevelChangedHandler processing started");

        var product = await _unitOfWork
            .Set<Product>()
            .FindAsync([eventData.ProductId], cancellationToken);

        if (product is null)
        {
            throw new InvalidOperationException($"Failed to set new Stock Level for a Product with ID {eventData.ProductId}");
        }

        product.UpdateStockLevel(eventData.NewStockLevel);
        await _unitOfWork.SaveChanges(cancellationToken);

        Console.WriteLine("> Catalog.StockLevelChangedHandler processing finished");
    }
}