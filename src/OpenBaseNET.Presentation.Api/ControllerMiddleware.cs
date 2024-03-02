namespace OpenBaseNET.Presentation.Api;

public class ControllerMiddleware(RequestDelegate next, ILogger<ControllerMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        logger.LogInformation("Path: {Path}", context.Request.Path);
        logger.LogInformation("Method: {Method}", context.Request.Method);
        logger.LogInformation("QueryString: {QueryString}", context.Request.QueryString.Value);
        await next(context);
    }
}