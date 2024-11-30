using Tycho.Requests;
using TychoConsole.Catalog.Contract.Entities;

namespace TychoConsole.Catalog.Contract.Incoming.Requests;

public record FindProduct(string ProductName) : IRequest<Product>;