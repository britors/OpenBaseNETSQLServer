namespace OpenBaseNET.Presentation.Api.Middlewares;

public class ControllerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
{
  public async Task InvokeAsync(HttpContext context)
  {
    
    if(logger.IsEnabled(LogLevel.Information))
    {
      logger.LogInformation("ControllerMiddleware: Processando a requisição {Method} {Path}",
      context.Request.Method,
      context.Request.Path);
    }

    await next(context);
  }
}

