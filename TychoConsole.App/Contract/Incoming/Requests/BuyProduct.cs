using Tycho.Requests;

namespace TychoConsole.App.Contract.Incoming.Requests;

public record BuyProduct(string ProductId, int Amount) : IRequest;