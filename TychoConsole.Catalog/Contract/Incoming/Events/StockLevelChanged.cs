using Tycho.Events;

namespace TychoConsole.Catalog.Contract.Incoming.Events;

public record StockLevelChanged(int ProductId, int NewStockLevel) : IEvent;