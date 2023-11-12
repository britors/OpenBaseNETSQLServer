using OpenBaseNET.Infra.Resilience.Core.Policies;
using OpenBaseNET.Infra.Resilience.Http.ExceptionPredicate;
using Polly.Retry;

namespace OpenBaseNET.Infra.Resilience.Http.Policies;

public static class HttpClientPolicy
{
    public static readonly AsyncRetryPolicy asyncRetryPolicy =
        BasePolicy<HttpRequestException>.GetAsyncRetryPolicy(HttpExceptionPredicate.ShouldRetryOn);
}