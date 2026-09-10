using System.Diagnostics;

namespace idobrin_aspnet_api.Middleware;

public class GatherRouteInformationMiddleware(RequestDelegate next, ILogger<GatherRouteInformationMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<GatherRouteInformationMiddleware> _logger = logger;

    public async Task Invoke(HttpContext context)
    {
        var address = context.Connection.RemoteIpAddress.ToString();
        var route = context.Request.Path.Value;
        var method = context.Request.Method;
        _logger.LogInformation("{Address} requested access to {Route} via {Method}", address, route, method);
        await _next(context);
    }
}