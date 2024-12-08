using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tycho.Persistence.EFCore;
using TychoConsole.Catalog.Core;

namespace TychoConsole.Catalog.Persistence;

internal class CatalogDbContext : TychoDbContext
{
    public DbSet<Product> Products { get; set; } = default!;

    public async Task InitDatabase()
    {
        await Database.EnsureDeletedAsync();
        await Database.EnsureCreatedAsync();
        Products.AddRange(
            new Product("Mug", 10, 100),
            new Product("T-shirt", 25, 100),
            new Product("Wristwatch", 50, 100));
        await SaveChangesAsync();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "TychoConsole.Catalog.db");
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }
}