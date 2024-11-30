using Tycho.Events;

namespace TychoConsole.Pricing.Contract.Outgoing.Events;

public record PriceChanged(string ProductId, decimal OldPrice, decimal NewPrice) : IEvent;