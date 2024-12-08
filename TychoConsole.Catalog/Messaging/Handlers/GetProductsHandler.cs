using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tycho.Persistence.EFCore;
using Tycho.Requests;
using TychoConsole.Catalog.Contract.Incoming.Requests;
using TychoConsole.Catalog.Core;
using static TychoConsole.Catalog.Contract.Incoming.Requests.GetProducts;

namespace TychoConsole.Catalog.Messaging.Handlers;

internal class GetProductsHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetProducts, Response>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Response> Handle(GetProducts requestData, CancellationToken cancellationToken)
    {
        Console.WriteLine("> Catalog.GetProductsHandler processing started");

        var products = await _unitOfWork
            .Set<Product>()
            .Select(product => new ProductData(
                product.Id,
                product.Name,
                product.Price,
                product.StockLevel))
            .ToListAsync(cancellationToken);

        Console.WriteLine("> Catalog.GetProductsHandler processing finished");
        return new(products.ToImmutableList());
    }
}