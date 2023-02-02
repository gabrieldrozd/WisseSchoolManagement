using Wisse.Common.Communication.External;

namespace Wisse.Shared.Abstractions.Communication.External.Notices;

public interface INoticeDispatcher
{
    Task PublishAsync<TNotice>(TNotice notice)
        where TNotice : class, INotice;
}