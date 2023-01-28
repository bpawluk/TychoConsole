using Tycho.Messaging.Payload;

namespace App.Contract;

public record BuyProductCommand(string ProductId, int Amount) : ICommand;
