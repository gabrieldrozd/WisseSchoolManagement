using Wisse.Common.Communication.External;

namespace Wisse.Shared.Abstractions.Communication.External.Notices;

public interface INoticeHandler<in TNotice>
    where TNotice : class, INotice
{
    Task HandleAsync(TNotice notice);
}