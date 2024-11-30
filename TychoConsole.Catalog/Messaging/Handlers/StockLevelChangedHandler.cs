using System;
using System.Threading;
using System.Threading.Tasks;
using Tycho.Events;
using TychoConsole.Catalog.Contract.Incoming.Events;

namespace TychoConsole.Catalog.Messaging.Handlers;

internal class StockLevelChangedHandler : IEventHandler<StockLevelChanged>
{
    public Task Handle(StockLevelChanged eventData, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}