using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Wisse.Shared.Infrastructure.Middleware;

public class HttpRequestMiddleware : IMiddleware
{
    private readonly ILogger<HttpRequestMiddleware> _logger;
    private readonly Stopwatch _timer;

    public HttpRequestMiddleware(ILogger<HttpRequestMiddleware> logger)
    {
        _logger = logger;
        _timer = new Stopwatch();
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        _logger.LogInformation(
            @"[HTTP {Method}] Handling: {Path}",
            context.Request.Method, context.Request.Path);

        _timer.Start();
        await next(context);
        _timer.Stop();

        _logger.LogInformation(
            @"[HTTP {Method}: {StatusCode}] Handled: {Path} in {ElapsedMilliseconds}ms",
            context.Request.Method, context.Response.StatusCode, context.Request.Path, _timer.ElapsedMilliseconds);
    }
}