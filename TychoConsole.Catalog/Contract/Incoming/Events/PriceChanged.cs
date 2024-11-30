using Tycho.Events;

namespace TychoConsole.Catalog.Contract.Incoming.Events;

public record PriceChanged(string ProductId, decimal OldPrice, decimal NewPrice) : IEvent;