using System.Threading;
using System.Threading.Tasks;
using Tycho.Events;
using TychoConsole.Pricing.Contract.Incoming.Events;

namespace TychoConsole.Pricing.Messaging.Handlers;

internal class StockLevelChangedHandler : IEventHandler<StockLevelChanged>
{
    public Task Handle(StockLevelChanged eventData, CancellationToken cancellationToken = default)
    {
        throw new System.NotImplementedException();
    }
}