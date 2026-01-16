/*
 * Name: ControllerMiddleware
 * Author: Rodrigo Brito <rodrigo@w3ti.com.br>
 * Type: Script
 * Create At:   01/16/2026
 * Last Update: 01/16/2026
 * Description:
 *      Middleware para log de requisições
 * Versions:
 * |--------------------------------------------------------------|
 * | Date           | Description                                 |
 * | 01/16/2026     | Criação do Middleware                       |
 * |--------------------------------------------------------------|
 */


namespace OpenBaseNET.Presentation.Api.Middlewares;

public class ControllerMiddleware(RequestDelegate next, ILogger<ControllerMiddleware> logger)
{
  public async Task InvokeAsync(HttpContext context)
  {
    if (logger.IsEnabled(LogLevel.Information))
      logger.LogInformation(
          "Path: {Path},  Method: {Method} e QueryString: {QueryString}",
          context.Request.Path,
          context.Request.Method,
          context.Request.QueryString.Value);

    await next(context);
  }
}

