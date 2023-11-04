using MediatR;

namespace ProjectTemplate.Application.Events.Logs;

public class TransactionLogEventHandler : INotificationHandler<TransactionLogEvent>
{

    public async Task Handle(TransactionLogEvent notification, CancellationToken cancellationToken)
    {
        await Task.FromResult(0);
    }
}