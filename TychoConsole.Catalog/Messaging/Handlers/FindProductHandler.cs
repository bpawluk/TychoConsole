using System.Threading;
using System.Threading.Tasks;
using Tycho.Requests;
using TychoConsole.Catalog.Contract.Entities;
using TychoConsole.Catalog.Contract.Incoming.Requests;

namespace TychoConsole.Catalog.Messaging.Handlers;

internal class FindProductHandler : IRequestHandler<FindProduct, Product>
{
    public Task<Product> Handle(FindProduct requestData, CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }
}