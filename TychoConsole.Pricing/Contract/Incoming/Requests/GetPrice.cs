using Tycho.Requests;

namespace TychoConsole.Pricing.Contract.Incoming.Requests;

public record GetPrice(string ProductId) : IRequest<decimal>;