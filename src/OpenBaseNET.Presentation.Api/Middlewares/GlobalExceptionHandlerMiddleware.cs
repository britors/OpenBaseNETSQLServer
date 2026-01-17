/*
 * Name: GlobalExceptionHandlerMiddleware
 * Author: Rodrigo Brito <rodrigo@w3ti.com.br>
 * Type: class
 * Create At:   10/25/2025
 * Last Update: 10/25/2025
 * Description:
 *      Execução de tratamento global de exceções
 * Versions:
 * |--------------------------------------------------------------|
 * | Date           | Description                                 |
 * | 10/25/2025     | Criação do GlobalExceptionHandlerMiddleware |
 * |--------------------------------------------------------------|
 */

using System.Net;
using System.Text.Json;

namespace OpenBaseNET.Presentation.Api.Middlewares;

public class GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
{
  public async Task InvokeAsync(HttpContext context)
  {
    try
    {
      await next(context);
    }
    catch (Exception ex)
    {
      if (logger.IsEnabled(LogLevel.Error))
      {
        logger.LogError(ex, "Ocorreu uma exceção não tratada: {Message}", ex.Message);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        var response = new
        {
          context.Response.StatusCode,
          Message = "Ocorreu um erro interno inesperado. Por favor, tente novamente mais tarde."
        };

        var jsonResponse = JsonSerializer.Serialize(response);
        await context.Response.WriteAsync(jsonResponse);
      }
    }
  }
}
