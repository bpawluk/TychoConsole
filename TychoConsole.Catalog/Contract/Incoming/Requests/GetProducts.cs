using System.Collections.Immutable;
using Tycho.Requests;
using TychoConsole.Catalog.Contract.Entities;

namespace TychoConsole.Catalog.Contract.Incoming.Requests;

public record GetProducts : IRequest<IImmutableList<Product>>;