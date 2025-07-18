namespace OpenBaseNET.Presentation.Api.Middlewares;

public class ControllerMiddleware(RequestDelegate next, ILogger<ControllerMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        logger.LogInformation(
            "Path: {Path},  Method: {Method} e QueryString: {QueryString}",
            context.Request.Path,
            context.Request.Method,
            context.Request.QueryString.Value);

        await next(context);
    }
}