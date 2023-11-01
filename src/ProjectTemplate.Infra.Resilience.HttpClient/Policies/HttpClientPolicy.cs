using Polly.Retry;
using ProjectTemplate.Infra.Resilience.Core.Policies;
using ProjectTemplate.Infra.Resilience.Http.ExceptionPredicate;

namespace ProjectTemplate.Infra.Resilience.Http.Policies;

public static class HttpClientPolicy
{
    public static readonly AsyncRetryPolicy asyncRetryPolicy =
        BasePolicy<HttpRequestException>.GetAsyncRetryPolicy(HttpExceptionPredicate.ShouldRetryOn);
}