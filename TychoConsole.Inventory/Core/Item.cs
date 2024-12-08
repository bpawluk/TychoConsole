namespace TychoConsole.Inventory.Core;

internal class Item(int id, int stockLevel)
{
    public int Id { get; set; } = id;

    public int StockLevel { get; private set; } = stockLevel;

    public void Reserve(int amount)
    {
        StockLevel -= amount;
    }
}