using System.Text.Json;
using MediatR;
using ProjectTemplate.Application.Events.Logs;
using ProjectTemplate.Domain.Context;

namespace ProjectTemplate.Application.Pipelines;

public sealed class LoggingBehaviour<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IPublisher _publisher;
    private readonly SessionContext _sessionContext;

    public LoggingBehaviour(
        SessionContext sessionContext,
        IPublisher publisher)
    {
        _sessionContext = sessionContext;
        _publisher = publisher;
    }

    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var log = new TransactionLogEvent
        {
            CorrelationId = _sessionContext.Correlationid,
            HandlerName = typeof(TRequest).Name,
            Request = JsonSerializer.Serialize(request),
            SessionContext = JsonSerializer.Serialize(_sessionContext)
        };
        var response = await next();
        if (response is not null) log.Success = true;
        log.Response = JsonSerializer.Serialize(response);
        await _publisher.Publish(log, cancellationToken);
        return response;
    }
}