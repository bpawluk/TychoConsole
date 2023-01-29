using Tycho.Messaging.Payload;

namespace TychoSample.Pricing.Contract;

public record PriceChangedEvent(string ProductId, decimal OldPrice, decimal NewPrice) : IEvent;
