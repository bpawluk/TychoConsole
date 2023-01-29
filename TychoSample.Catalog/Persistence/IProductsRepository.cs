using System.Collections.Generic;
using TychoSample.Catalog.Contract.Model;

namespace TychoSample.Catalog.Persistence;

internal interface IProductsRepository
{
    IEnumerable<Product> GetProducts();
    Product? FindProduct(string nameQuery);
    void UpdatePrice(string productId, decimal newPrice);
    void UpdateStockLevel(string productId, int newLevel);
}
