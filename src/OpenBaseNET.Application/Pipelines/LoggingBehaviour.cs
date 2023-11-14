using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Logging;
using OpenBaseNET.Domain.Context;

namespace OpenBaseNET.Application.Pipelines;

public sealed class LoggingBehaviour<TRequest, TResponse>(SessionContext sessionContext,
        ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
    :
        IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = await next();
        logger.LogInformation($"TransactionLogEvent Id: {sessionContext.Correlationid.ToString()}");
        logger.LogInformation($"TransactionLogEvent Handler: {typeof(TResponse).Name}");
        logger.LogInformation($"TransactionLogEvent Host: {sessionContext.Host}");
        logger.LogInformation($"TransactionLogEvent Path: {sessionContext.Path}");
        logger.LogInformation($"TransactionLogEvent QueryString: {sessionContext.QueryString}");
        logger.LogInformation($"TransactionLogEvent Method: {sessionContext.Method}");
        logger.LogInformation($"TransactionLogEvent Body: {sessionContext.Body}");
        logger.LogInformation($"TransactionLogEvent Headers: " +
                               $"{JsonSerializer.Serialize(sessionContext.Headers)}");
        logger.LogInformation($"TransactionLogEvent Request: {JsonSerializer.Serialize(request)}");
        logger.LogInformation($"TransactionLogEvent Success: {response is not null}");
        logger.LogInformation($"TransactionLogEvent Date: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
        logger.LogInformation($"TransactionLogEvent Response: {JsonSerializer.Serialize(response)}");
        return response;
    }
}