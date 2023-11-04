using MediatR;
using Microsoft.Extensions.Logging;
using ProjectTemplate.Application.Events.Logs;
using ProjectTemplate.Domain.Context;
using System.Text.Json;

namespace ProjectTemplate.Application.Pipelines;

public class LoggingBehaviour<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;
    private readonly SessionContext _sessionContext;
    private readonly IPublisher _publisher;

    public LoggingBehaviour(
        ILogger<LoggingBehaviour<TRequest, TResponse>> logger,
        SessionContext sessionContext,
        IPublisher publisher)
    {
        _logger = logger;
        _sessionContext = sessionContext;
        _publisher = publisher;
    }

    public async Task<TResponse> Handle(TRequest request,
        CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        var log = new TransactionLogEvent
        {
            CorrelationId = _sessionContext.Correlationid,
            HandlerName = typeof(TRequest).Name,
            Request = JsonSerializer.Serialize(request),
            SessionContext = JsonSerializer.Serialize(_sessionContext)
        };

        _logger.LogInformation($"Inicio da Sessão: {_sessionContext.Correlationid}");
        _logger.LogInformation($"Handling {typeof(TRequest).Name}");

        var response = await next();
        log.Response = JsonSerializer.Serialize(response);
        await _publisher.Publish(log, cancellationToken);

        _logger.LogInformation($"Handled {typeof(TResponse).Name}");
        _logger.LogInformation($"Response: {JsonSerializer.Serialize(response)}");
        _logger.LogInformation($"Fim da Sessão: {_sessionContext.Correlationid}");
        return response;
    }
}