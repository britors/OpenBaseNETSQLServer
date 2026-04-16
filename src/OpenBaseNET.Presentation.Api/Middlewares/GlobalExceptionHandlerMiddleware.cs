using FluentValidation;
using Microsoft.AspNetCore.Mvc;
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
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        logger.LogError(exception, "Exceção não tratada: {Message}", exception.Message);

        var (statusCode, title, detail) = exception switch
        {
            ValidationException validationEx => (
                HttpStatusCode.UnprocessableEntity,
                "Erro de validação",
                string.Join("; ", validationEx.Errors.Select(e => e.ErrorMessage))
            ),

            KeyNotFoundException => (
                HttpStatusCode.NotFound,
                "Recurso não encontrado",
                exception.Message
            ),

            ArgumentException => (
                HttpStatusCode.BadRequest,
                "Requisição inválida",
                exception.Message
            ),

            _ => (
                HttpStatusCode.InternalServerError,
                "Erro interno do servidor",
                "Ocorreu um erro inesperado. Por favor, tente novamente mais tarde."
            )
        };
        
        var problemDetails = new ProblemDetails
        {
            Status = (int)statusCode,
            Title = title,
            Detail = detail,
            Instance = context.Request.Path
        };

        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = (int)statusCode;

        await context.Response.WriteAsync(
            JsonSerializer.Serialize(problemDetails,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));
    }
}