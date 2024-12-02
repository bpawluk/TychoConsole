using Tycho.Requests;

namespace TychoConsole.App.Contract.Incoming.Requests;

public record BuyProduct(int ProductId, int Amount) : IRequest;