using MediatR;
using Microsoft.Extensions.Logging;

namespace ProjectTemplate.Application.Events.Logs;

public class TransactionLogEventHandler : INotificationHandler<TransactionLogEvent>
{
    private readonly ILogger<TransactionLogEventHandler> _logger;

    public TransactionLogEventHandler(ILogger<TransactionLogEventHandler> logger)
    {
        _logger = logger;
    }

    public async Task Handle(TransactionLogEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"TransactionLogEvent: {notification.CorrelationId}");
        _logger.LogInformation($"TransactionLogEvent: {notification.HandlerName}");
        _logger.LogInformation($"TransactionLogEvent: {notification.Success}");
        await Task.FromResult(0);
    }
}