namespace TychoConsole.Inventory.Core.Abstraction;

internal interface IStockLevelsRepository
{
    void ReserveProduct(string productId, int amount);
}
