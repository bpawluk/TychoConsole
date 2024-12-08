using Tycho.Events;

namespace TychoConsole.Pricing.Contract.Outgoing.Events;

public record PriceChanged(int ProductId, decimal NewPrice) : IEvent;