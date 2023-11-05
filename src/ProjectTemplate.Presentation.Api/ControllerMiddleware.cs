using ProjectTemplate.Domain.Context;

namespace ProjectTemplate.Presentation.Api;

public class ControllerMiddleware
{
    private readonly RequestDelegate _next;

    public ControllerMiddleware(RequestDelegate next)
        => _next = next;

    public async Task InvokeAsync(HttpContext context, SessionContext sessionContext)
    {
        sessionContext.Correlationid = Guid.NewGuid();
        sessionContext.Host = context.Request.Host.Value;
        sessionContext.Path = context.Request.Path.Value ?? "";
        sessionContext.QueryString = context.Request.QueryString.Value ?? "";
        sessionContext.Method = context.Request.Method;
        sessionContext.Headers = context.Request.Headers.ToDictionary(x => x.Key, x => x.Value.ToString());
        await _next(context);
    }
}