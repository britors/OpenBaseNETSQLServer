namespace OpenBaseNET.Infra.Resilience.Http.ExceptionPredicate;

internal static class HttpExceptionPredicate
{
    private const int ServerError = 500;

    internal static bool ShouldRetryOn(HttpRequestException exception)
    {
        return (int?)exception.StatusCode switch
        {
            >= ServerError => true,
            _ => false
        };
    }
}