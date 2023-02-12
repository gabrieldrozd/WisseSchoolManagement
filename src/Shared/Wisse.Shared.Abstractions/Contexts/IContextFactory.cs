namespace Wisse.Shared.Abstractions.Contexts;

public interface IContextFactory
{
    IUserContext Create();
}