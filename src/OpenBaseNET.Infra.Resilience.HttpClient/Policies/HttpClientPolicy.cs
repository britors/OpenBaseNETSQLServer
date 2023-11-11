using Polly.Retry;
using OpenBaseNET.Infra.Resilience.Core.Policies;
using OpenBaseNET.Infra.Resilience.Http.ExceptionPredicate;

namespace OpenBaseNET.Infra.Resilience.Http.Policies;

public static class HttpClientPolicy
{
    public static readonly AsyncRetryPolicy asyncRetryPolicy =
        BasePolicy<HttpRequestException>.GetAsyncRetryPolicy(HttpExceptionPredicate.ShouldRetryOn);
}