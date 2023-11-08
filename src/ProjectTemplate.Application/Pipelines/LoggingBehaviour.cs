using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Logging;
using ProjectTemplate.Domain.Context;

namespace ProjectTemplate.Application.Pipelines;

public sealed class LoggingBehaviour<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;
    private readonly SessionContext _sessionContext;

    public LoggingBehaviour(
        SessionContext sessionContext,
        ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
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
        _logger.LogInformation($"TransactionLogEvent Request: {JsonSerializer.Serialize(request)}");
        _logger.LogInformation($"TransactionLogEvent Success: {response is null}");
        _logger.LogInformation($"TransactionLogEvent Date: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
        _logger.LogInformation($"TransactionLogEvent Response: {JsonSerializer.Serialize(response)}");
        return response;
    }
}