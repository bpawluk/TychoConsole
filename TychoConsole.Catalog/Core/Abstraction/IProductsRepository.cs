using System.Collections.Generic;

namespace TychoConsole.Catalog.Core.Abstraction;

internal interface IProductsRepository
{
    IEnumerable<Contract.Entities.Product> GetProducts();

    Contract.Entities.Product? FindProduct(string nameQuery);

    void UpdatePrice(string productId, decimal newPrice);

    void UpdateStockLevel(string productId, int newLevel);
}