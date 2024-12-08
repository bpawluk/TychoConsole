using System.Collections.Immutable;
using Tycho.Requests;
using static TychoConsole.Catalog.Contract.Incoming.Requests.GetProducts;

namespace TychoConsole.Catalog.Contract.Incoming.Requests;

public record GetProducts : IRequest<Response>
{
    public record Response(IImmutableList<ProductData> Products);

    public record ProductData(int Id, string Name, decimal Price, int StockLevel)
    {
        public override string ToString()
        {
            return $"- {Id} - {Name,-10} - {Price:C} - {StockLevel,3}";
        }
    }
}