﻿using App;
using App.Contract;
using Catalog.Contract;
using Catalog.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tycho;

namespace TychoSample;

internal class Program
{
    static async Task Main()
    {
        var app = await new AppModule().Build();

        Console.WriteLine("Start with the following store catalog:");
        await PrintStoreCatalog(app);

        Console.WriteLine("\nLook for watches...");
        var watch = await app.Execute<FindProductQuery, Product>(new("watch"));
        Console.WriteLine(watch);

        Console.WriteLine("... and buy 10 of them.");
        await app.Execute<BuyProductCommand>(new(watch.Id, 10));

        Console.WriteLine("\nNow the store catalog looks like this:");
        await PrintStoreCatalog(app);
    }

    private static async Task PrintStoreCatalog(IModule app)
    {
        var products = await app.Execute<GetProductsQuery, IEnumerable<Product>>(new());
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }
    }
}