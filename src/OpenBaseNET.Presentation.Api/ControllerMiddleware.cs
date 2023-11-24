namespace OpenBaseNET.Presentation.Api;

public class ControllerMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        await next(context);
    }
}