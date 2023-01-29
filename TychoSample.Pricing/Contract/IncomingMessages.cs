using Tycho.Messaging.Payload;

namespace TychoSample.Pricing.Contract;

public record GetPriceQuery(string ProductId) : IQuery<decimal>;
public record StockLevelChangedEvent(string ProductId, int OldLevel, int NewLevel) : IEvent;
