namespace OpenBaseNET.Presentation.Api.Middlewares;

public class ControllerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
{
  public async Task InvokeAsync(HttpContext context)
  {
    await next(context);
  }
}

