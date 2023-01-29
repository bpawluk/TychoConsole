using System.Collections.Generic;
using System.Threading.Tasks;
using Tycho;
using TychoSample.App;
using TychoSample.App.Contract;
using TychoSample.Catalog.Contract;
using TychoSample.Catalog.Contract.Model;
using static System.Console;

namespace TychoSample.Console;

internal class Program
{
    static async Task Main()
    {
        var app = await new AppModule().Build();

        WriteLine("Start with the following store catalog:");
        await PrintStoreCatalog(app);

        WriteLine("\nLook for watches...");
        var watch = await app.Execute<FindProductQuery, Product>(new("watch"));
        WriteLine(watch);

        WriteLine("... and buy 10 of them.");
        await app.Execute<BuyProductCommand>(new(watch.Id, 10));

        WriteLine("\nNow the store catalog looks like this:");
        await PrintStoreCatalog(app);
    }

    private static async Task PrintStoreCatalog(IModule app)
    {
        var products = await app.Execute<GetProductsQuery, IEnumerable<Product>>(new());
        foreach (var product in products) WriteLine(product);
    }
}