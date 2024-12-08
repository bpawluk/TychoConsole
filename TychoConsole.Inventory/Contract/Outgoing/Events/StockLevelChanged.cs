using Tycho.Events;

namespace TychoConsole.Inventory.Contract.Outgoing.Events;

public record StockLevelChanged(int ItemId, int NewStockLevel) : IEvent;