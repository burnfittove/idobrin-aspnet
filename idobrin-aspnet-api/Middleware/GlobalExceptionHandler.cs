using Microsoft.AspNetCore.Mvc;

namespace idobrin_aspnet_api.Middleware;

public class GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<GlobalExceptionHandler> _logger = logger;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Unhandled exception");
            await ExceptionHandlerAsync(context, e);
        }
    }

    private static async Task ExceptionHandlerAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 500;

        var problemDetails = new ProblemDetails
        {
            Status = context.Response.StatusCode,
            Title = "An unhandled exception occurred.",
            Detail = exception.Message,
            Type = exception.GetType().Name,
        };
        
        await context.Response.WriteAsJsonAsync(problemDetails);
    }
}