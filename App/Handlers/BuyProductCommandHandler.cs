using App.Contract;
using Inventory;
using Inventory.Contract;
using System.Threading;
using System.Threading.Tasks;
using Tycho;
using Tycho.Messaging.Handlers;

namespace App.Handlers;

internal class BuyProductCommandHandler : ICommandHandler<BuyProductCommand>
{
    private readonly IModule<InventoryModule> _inventoryModule;

    public BuyProductCommandHandler(IModule<InventoryModule> inventoryModule)
    {
        _inventoryModule = inventoryModule;
    }

    public Task Handle(BuyProductCommand commandData, CancellationToken cancellationToken)
    {
        return _inventoryModule.Execute(
            new ReserveProductCommand(
                commandData.ProductId, 
                commandData.Amount), 
            cancellationToken);
    }
}
