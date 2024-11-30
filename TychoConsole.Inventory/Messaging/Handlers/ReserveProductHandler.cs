using System.Threading;
using System.Threading.Tasks;
using Tycho.Requests;
using TychoConsole.Inventory.Contract.Incoming.Requests;

namespace TychoConsole.Inventory.Messaging.Handlers;

internal class ReserveProductHandler : IRequestHandler<ReserveProduct>
{
    Task IRequestHandler<ReserveProduct>.Handle(ReserveProduct requestData, CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }
}