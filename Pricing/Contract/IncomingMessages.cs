using Tycho.Messaging.Payload;

namespace Pricing.Contract;

public record GetPriceQuery(string ProductId) : IQuery<decimal>;
public record StockLevelChangedEvent(string ProductId, int OldLevel, int NewLevel) : IEvent;
