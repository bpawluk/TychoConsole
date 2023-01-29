using Tycho.Messaging.Payload;

namespace TychoSample.App.Contract;

public record BuyProductCommand(string ProductId, int Amount) : ICommand;
