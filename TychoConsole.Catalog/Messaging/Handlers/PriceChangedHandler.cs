using System;
using System.Threading;
using System.Threading.Tasks;
using Tycho.Events;
using TychoConsole.Catalog.Contract.Incoming.Events;

namespace TychoConsole.Catalog.Messaging.Handlers;

internal class PriceChangedHandler : IEventHandler<PriceChanged>
{
    public Task Handle(PriceChanged eventData, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}