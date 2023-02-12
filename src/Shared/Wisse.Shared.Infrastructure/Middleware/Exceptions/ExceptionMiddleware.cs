using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Wisse.Shared.Abstractions.Exceptions;

namespace Wisse.Shared.Infrastructure.Middleware.Exceptions;

internal class ExceptionMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IExceptionMapper _exceptionMapper;

    public ExceptionMiddleware(
        ILogger<ExceptionMiddleware> logger,
        IExceptionMapper exceptionMapper)
    {
        _logger = logger;
        _exceptionMapper = exceptionMapper;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.Message);
            await HandleExceptionAsync(context, exception);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var envelope = _exceptionMapper.Map(exception);
        context.Response.StatusCode = envelope?.StatusCode ?? 500;
        if (envelope is null)
        {
            return;
        }

        await context.Response.WriteAsJsonAsync(envelope);
    }
}
