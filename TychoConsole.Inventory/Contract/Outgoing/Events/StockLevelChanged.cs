using Tycho.Events;

namespace TychoConsole.Inventory.Contract.Outgoing.Events;

public record StockLevelChanged(string ProductId, int PreviousLevel, int CurrentLevel) : IEvent;