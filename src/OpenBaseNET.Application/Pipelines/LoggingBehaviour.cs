using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace OpenBaseNET.Application.Pipelines;

public sealed class LoggingBehaviour<TRequest, TResponse>(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        try
        {
            
            logger.LogInformation($"Chamando o comando {requestName} com valores {JsonSerializer.Serialize(request)}");
            var response = await next();
            logger.LogInformation($"Resposta para  o comando {requestName} foi {JsonSerializer.Serialize(response)}");
            return response;
        }
        catch(Exception e)
        {
            logger.LogError($"Ocorreu um erro ao chamar o comando {requestName}:  {e.Message}");
            logger.LogError($"StackTrace: {e.StackTrace}");
#pragma warning disable CS8603 // Possible null reference return.
            return default;
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}