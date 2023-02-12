namespace Wisse.Shared.Abstractions.Contexts;

public interface IContext
{
    string RequestId { get; }
    string TraceId { get; }
    IUserContext User { get; }
}