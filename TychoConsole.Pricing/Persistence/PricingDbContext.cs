using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tycho.Persistence.EFCore;
using TychoConsole.Pricing.Core;

namespace TychoConsole.Pricing.Persistence;

internal class PricingDbContext : TychoDbContext
{
    public DbSet<Product> Products { get; set; } = default!;

    public async Task InitDatabase()
    {
        await Database.EnsureDeletedAsync();
        await Database.EnsureCreatedAsync();
        Products.AddRange(
            new Product(1, 10, 100),
            new Product(2, 25, 100),
            new Product(3, 50, 100));
        await SaveChangesAsync();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "TychoConsole.Pricing.db");
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }
}