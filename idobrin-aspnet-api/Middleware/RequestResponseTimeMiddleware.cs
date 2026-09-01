namespace idobrin_aspnet_api.Middleware;

public class RequestResponseTimeMiddleware(RequestDelegate next, ILogger<RequestResponseTimeMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<RequestResponseTimeMiddleware> _logger = logger;

    public async Task Invoke(HttpContext context)
    {
        var startTime = DateTime.Now;
        await _next.Invoke(context);
        var endTime = DateTime.Now;
        var totalTime = (endTime - startTime).TotalMilliseconds;
        var request = context.Request.Path.Value;
        _logger.LogInformation("Request to {RequestPath} took: {TotalTime} ms.", request, totalTime);
    }
}