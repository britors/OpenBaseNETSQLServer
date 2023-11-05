using MediatR;

namespace ProjectTemplate.Application.Events.Logs;

public class TransactionLogEvent : INotification
{
    public Guid CorrelationId { get; set; } = Guid.Empty;
    public string SessionContext { get; set; } = string.Empty;
    public string HandlerName { get; set; } = string.Empty;
    public string Request { get; set; } = string.Empty;
    public string Response { get; set; } = string.Empty;
    public bool Success { get; set; }
    public bool Failure => !Success;
    public DateTime Date { get; } = DateTime.Now;
}