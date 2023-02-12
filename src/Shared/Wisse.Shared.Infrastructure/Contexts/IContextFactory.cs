using Wisse.Shared.Abstractions.Contexts;

namespace Wisse.Shared.Infrastructure.Contexts;

internal interface IContextFactory
{
    IContext Create();
}