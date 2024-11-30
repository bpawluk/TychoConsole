using Tycho.Requests;

namespace TychoConsole.Inventory.Contract.Incoming.Requests;

public record ReserveProduct(string ProductId, int Amount) : IRequest;