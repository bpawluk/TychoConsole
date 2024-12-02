using System;
using System.Threading;
using System.Threading.Tasks;
using Tycho.Requests;
using Tycho.Structure;
using TychoConsole.App.Contract.Incoming.Requests;
using TychoConsole.Inventory;
using TychoConsole.Inventory.Contract.Incoming.Requests;

namespace TychoConsole.App.Messaging.Handlers;

internal class BuyProductHandler(IModule<InventoryModule> inventoryModule) : IRequestHandler<BuyProduct>
{
    private readonly IModule<InventoryModule> _inventoryModule = inventoryModule;

    public async Task Handle(BuyProduct requestData, CancellationToken cancellationToken)
    {
        Console.WriteLine("> StoreApp.BuyProductHandler processing started");
        await _inventoryModule.Execute(
            new ReserveItem(requestData.ProductId, requestData.Amount),
            cancellationToken);
        Console.WriteLine("> StoreApp.BuyProductHandler processing finished");
    }
}