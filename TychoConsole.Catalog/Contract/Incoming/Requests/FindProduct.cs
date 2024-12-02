using Tycho.Requests;
using static TychoConsole.Catalog.Contract.Incoming.Requests.FindProduct;

namespace TychoConsole.Catalog.Contract.Incoming.Requests;

public record FindProduct(string ProductName) : IRequest<Response>
{
    public record Response(ProductData? Product);

    public record ProductData(int Id, string Name, decimal Price, int StockLevel)
    {
        public override string ToString()
        {
            return $"- {Id} - {Name,-10} - {Price:C} - {StockLevel,3}";
        }
    }
}