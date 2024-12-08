using Tycho.Events;

namespace TychoConsole.Pricing.Contract.Incoming.Events;

public record StockLevelChanged(int ProductId, int NewStockLevel) : IEvent;