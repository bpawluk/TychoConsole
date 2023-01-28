using Tycho.Messaging.Payload;

namespace Pricing.Contract;

public record PriceChangedEvent(string ProductId, decimal OldPrice, decimal NewPrice) : IEvent;
