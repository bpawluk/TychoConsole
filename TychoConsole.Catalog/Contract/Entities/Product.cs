namespace TychoConsole.Catalog.Contract.Entities;

public record Product(string Id, string Name, decimal Price, int StockLevel)
{
    public override string ToString()
    {
        return $"> {Id} - {Name,-10} - {Price:C} - {StockLevel,3}";
    }
}