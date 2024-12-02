using Tycho.Events;

namespace TychoConsole.Catalog.Contract.Incoming.Events;

public record PriceChanged(int ProductId, decimal NewPrice) : IEvent;