using Tycho.Messaging.Payload;

namespace TychoSample.Inventory.Contract;

public record ReserveProductCommand(string ProductId, int Amount) : ICommand;
