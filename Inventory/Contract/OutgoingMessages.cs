using Tycho.Messaging.Payload;

namespace Inventory.Contract;

public record StockLevelChangedEvent(string ProductId, int PreviousLevel, int CurrentLevel) : IEvent;
