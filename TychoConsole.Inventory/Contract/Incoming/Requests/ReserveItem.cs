using Tycho.Requests;

namespace TychoConsole.Inventory.Contract.Incoming.Requests;

public record ReserveItem(int ItemId, int Amount) : IRequest;