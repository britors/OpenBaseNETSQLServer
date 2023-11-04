using MediatR;

namespace ProjectTemplate.Application.Events.Logs;

internal class TransactionLogEventHandler : INotificationHandler<TransactionLogEvent>
{
    public async Task Handle(TransactionLogEvent notification, CancellationToken cancellationToken)
    {
        Task.FromResult(0);
    }
}