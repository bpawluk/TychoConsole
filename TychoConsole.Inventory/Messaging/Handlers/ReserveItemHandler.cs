using System;
using System.Threading;
using System.Threading.Tasks;
using Tycho.Persistence.EFCore;
using Tycho.Requests;
using TychoConsole.Inventory.Contract.Incoming.Requests;
using TychoConsole.Inventory.Contract.Outgoing.Events;
using TychoConsole.Inventory.Core;

namespace TychoConsole.Inventory.Messaging.Handlers;

internal class ReserveItemHandler(IUnitOfWork unitOfWork) : IRequestHandler<ReserveItem>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(ReserveItem requestData, CancellationToken cancellationToken)
    {
        Console.WriteLine("> Inventory.ReserveItemHandler processing started");

        var item = await _unitOfWork
            .Set<Item>()
            .FindAsync([requestData.ItemId], cancellationToken);

        if (item is null)
        {
            throw new InvalidOperationException($"Failed to Reserve Item with ID {requestData.ItemId}");
        }

        item.Reserve(requestData.Amount);
        await _unitOfWork.Publish(new StockLevelChanged(item.Id, item.StockLevel));

        await _unitOfWork.SaveChanges(cancellationToken);
        Console.WriteLine("> Inventory.ReserveItemHandler processing finished");
    }
}