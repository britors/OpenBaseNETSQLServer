namespace OpenBaseNET.Infra.Resilience.Core.ExceptionPredicate;

internal static class TimeoutExceptionPredicate
{
    internal static bool ShouldRetryOn(TimeoutException exception)
    {
        return exception.Message.Contains("Timeout");
    }
}