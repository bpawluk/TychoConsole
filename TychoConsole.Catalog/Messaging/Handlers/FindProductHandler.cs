using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tycho.Persistence.EFCore;
using Tycho.Requests;
using TychoConsole.Catalog.Contract.Incoming.Requests;
using TychoConsole.Catalog.Core;
using static TychoConsole.Catalog.Contract.Incoming.Requests.FindProduct;

namespace TychoConsole.Catalog.Messaging.Handlers;

internal class FindProductHandler(IUnitOfWork unitOfWork) : IRequestHandler<FindProduct, Response>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Response> Handle(FindProduct requestData, CancellationToken cancellationToken)
    {
        Console.WriteLine("> Catalog.FindProductHandler processing started");

        var foundProduct = await _unitOfWork
            .Set<Product>()
            .Where(product => product.Name == requestData.ProductName)
            .Select(product => new ProductData(
                product.Id,
                product.Name,
                product.Price,
                product.StockLevel))
            .FirstOrDefaultAsync(cancellationToken);

        Console.WriteLine("> Catalog.FindProductHandler processing finished");
        return new(foundProduct);
    }
}