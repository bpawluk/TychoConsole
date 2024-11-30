using Tycho.Events;

namespace TychoConsole.Catalog.Contract.Incoming.Events;

public record StockLevelChanged(string ProductId, int OldLevel, int NewLevel) : IEvent;