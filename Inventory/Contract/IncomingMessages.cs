using Tycho.Messaging.Payload;

namespace Inventory.Contract;

public record ReserveProductCommand(string ProductId, int Amount) : ICommand;
