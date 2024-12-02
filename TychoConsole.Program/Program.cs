using System.Collections.Generic;
using System.Threading.Tasks;
using Tycho.Structure;
using TychoConsole.App;
using TychoConsole.App.Contract.Incoming.Requests;
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

        WriteLine("\nLook for a Wristwatch:");
        var response = await app.Execute<FindProduct, FindProduct.Response>(new("Wristwatch"));
        WriteLine(response.Product);

        WriteLine("\nBuy 10 of them and wait a bit...");
        await app.Execute<BuyProduct>(new(response.Product!.Id, 10));
        await Task.Delay(1000);

        WriteLine("\nNow the store catalog looks like this:");
        await PrintStoreCatalog(app);

        ReadKey();
    }

    private static async Task PrintStoreCatalog(IApp app)
    {
        var response = await app.Execute<GetProducts, GetProducts.Response>(new());
        foreach (var product in response.Products) WriteLine(product);
    }
}