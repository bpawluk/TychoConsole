namespace TychoConsole.Catalog.Core;

internal class Product(string name, decimal price, int stockLevel)
{
    public int Id { get; private set; }

    public string Name { get; private set; } = name;

    public decimal Price { get; private set; } = price;

    public int StockLevel { get; private set; } = stockLevel;

    public void UpdatePrice(decimal newPrice)
    {
        Price = newPrice;
    }

    public void UpdateStockLevel(int newLevel)
    {
        StockLevel = newLevel;
    }
}