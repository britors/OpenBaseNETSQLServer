using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Logging;
using OpenBaseNET.Domain.Context;

namespace OpenBaseNET.Application.Pipelines;

public sealed class LoggingBehaviour<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;
    private readonly SessionContext _sessionContext;

    public LoggingBehaviour(
        SessionContext sessionContext,
        ILogger<LoggingBehaviour<TRequest, TResponse>> logger
    )
    {
        _sessionContext = sessionContext;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = await next();
        _logger.LogInformation($"TransactionLogEvent Id: {_sessionContext.Correlationid.ToString()}");
        _logger.LogInformation($"TransactionLogEvent Handler: {typeof(TResponse).Name}");
        _logger.LogInformation($"TransactionLogEvent Host: {_sessionContext.Host}");
        _logger.LogInformation($"TransactionLogEvent Path: {_sessionContext.Path}");
        _logger.LogInformation($"TransactionLogEvent QueryString: {_sessionContext.QueryString}");
        _logger.LogInformation($"TransactionLogEvent Method: {_sessionContext.Method}");
        _logger.LogInformation($"TransactionLogEvent Body: {_sessionContext.Body}");
        _logger.LogInformation($"TransactionLogEvent Headers: " +
                               $"{JsonSerializer.Serialize(_sessionContext.Headers)}");
        _logger.LogInformation($"TransactionLogEvent Request: {JsonSerializer.Serialize(request)}");
        _logger.LogInformation($"TransactionLogEvent Success: {response is not null}");
        _logger.LogInformation($"TransactionLogEvent Date: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
        _logger.LogInformation($"TransactionLogEvent Response: {JsonSerializer.Serialize(response)}");
        return response;
    }
}