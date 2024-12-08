using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tycho.Persistence.EFCore;
using TychoConsole.Inventory.Core;

namespace TychoConsole.Inventory.Persistence;

internal class InventoryDbContext : TychoDbContext
{
    public DbSet<Item> Items { get; set; } = default!;

    public async Task InitDatabase()
    {
        await Database.EnsureDeletedAsync();
        await Database.EnsureCreatedAsync();
        Items.AddRange(
            new Item(1, 100),
            new Item(2, 100),
            new Item(3, 100));
        await SaveChangesAsync();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "TychoConsole.Inventory.db");
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }
}