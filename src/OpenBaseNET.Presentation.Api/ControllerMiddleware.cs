namespace OpenBaseNET.Presentation.Api;

public class ControllerMiddleware(RequestDelegate next, ILogger<ControllerMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        logger.LogInformation(context.Request.Path);
        logger.LogInformation(context.Request.Method);
        logger.LogInformation(context.Request.QueryString.Value);
        await next(context);
    }
}