using System;
using System.Threading;
using System.Threading.Tasks;
using Tycho.Requests;
using TychoConsole.Pricing.Contract.Incoming.Requests;

namespace TychoConsole.Pricing.Messaging.Handlers;

internal class GetPriceHandler : IRequestHandler<GetPrice, decimal>
{
    public Task<decimal> Handle(GetPrice requestData, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}