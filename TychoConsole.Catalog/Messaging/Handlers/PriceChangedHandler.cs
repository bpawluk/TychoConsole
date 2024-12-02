using System;
using System.Threading;
using System.Threading.Tasks;
using Tycho.Events;
using Tycho.Persistence.EFCore;
using TychoConsole.Catalog.Contract.Incoming.Events;
using TychoConsole.Catalog.Core;

namespace TychoConsole.Catalog.Messaging.Handlers;

internal class PriceChangedHandler(IUnitOfWork unitOfWork) : IEventHandler<PriceChanged>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(PriceChanged eventData, CancellationToken cancellationToken)
    {
        Console.WriteLine("> Catalog.PriceChangedHandler processing started");

        var product = await _unitOfWork
            .Set<Product>()
            .FindAsync([eventData.ProductId], cancellationToken);

        if (product is null)
        {
            throw new InvalidOperationException($"Failed to set new Price for a Product with ID {eventData.ProductId}");
        }

        product.UpdatePrice(eventData.NewPrice);
        await _unitOfWork.SaveChanges(cancellationToken);

        Console.WriteLine("> Catalog.PriceChangedHandler processing finished");
    }
}