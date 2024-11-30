using System.Collections.Generic;
using System.Threading.Tasks;
using Tycho.Structure;
using TychoConsole.App;
using TychoConsole.App.Contract.Incoming.Requests;
using TychoConsole.Catalog.Contract.Entities;
using TychoConsole.Catalog.Contract.Incoming.Requests;
using static System.Console;

namespace TychoConsole.Program;

internal class Program
{
    static async Task Main()
    {
        var app = await new StoreApp().Run();

        WriteLine("Start with the following store catalog:");
        await PrintStoreCatalog(app);

        WriteLine("\nLook for watches...");
        var watch = await app.Execute<FindProduct, Product>(new("watch"));
        WriteLine(watch);

        WriteLine("... and buy 10 of them.");
        await app.Execute<BuyProduct>(new(watch.Id, 10));

        WriteLine("\nNow the store catalog looks like this:");
        await PrintStoreCatalog(app);
    }

    private static async Task PrintStoreCatalog(IApp app)
    {
        var products = await app.Execute<GetProducts, IEnumerable<Product>>(new());
        foreach (var product in products) WriteLine(product);
    }
}