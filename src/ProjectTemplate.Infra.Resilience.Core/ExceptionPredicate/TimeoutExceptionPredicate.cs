namespace ProjectTemplate.Infra.Resilience.Core.ExceptionPredicate;

internal static class TimeoutExceptionPredicate
{
    internal static bool ShouldRetryOn(TimeoutException exception)
    {
        return exception.Message is not null && exception.Message.Contains("Timeout");
    }
}