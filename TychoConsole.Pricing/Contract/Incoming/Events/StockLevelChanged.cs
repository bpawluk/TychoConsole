using Tycho.Events;

namespace TychoConsole.Pricing.Contract.Incoming.Events;

public record StockLevelChanged(string ProductId, int OldLevel, int NewLevel) : IEvent;