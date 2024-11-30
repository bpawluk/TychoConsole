using System;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Tycho.Requests;
using TychoConsole.Catalog.Contract.Entities;
using TychoConsole.Catalog.Contract.Incoming.Requests;

namespace TychoConsole.Catalog.Messaging.Handlers;

internal class GetProductsHandler : IRequestHandler<GetProducts, IImmutableList<Product>>
{
    public Task<IImmutableList<Product>> Handle(GetProducts requestData, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}