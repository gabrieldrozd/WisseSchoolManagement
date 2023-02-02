using Microsoft.Extensions.DependencyInjection;
using Wisse.Common.Communication.External;
using Wisse.Shared.Abstractions.Communication.External.Notices;

namespace Wisse.Shared.Infrastructure.Communication.External.Notices;

internal sealed class NoticeDispatcher : INoticeDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public NoticeDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task PublishAsync<TNotice>(TNotice notice) where TNotice : class, INotice
    {
        using var scope = _serviceProvider.CreateScope();
        var handlers = scope.ServiceProvider.GetServices<INoticeHandler<TNotice>>();

        var tasks = handlers.Select(handler => handler.HandleAsync(notice));
        await Task.WhenAll(tasks);
    }
}