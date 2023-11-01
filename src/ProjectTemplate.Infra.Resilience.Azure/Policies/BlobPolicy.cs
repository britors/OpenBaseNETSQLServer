using Azure;
using Polly.Retry;
using ProjectTemplate.Infra.Resilience.Azure.ExceptionPredicate;
using ProjectTemplate.Infra.Resilience.Core.Policies;

namespace ProjectTemplate.Infra.Resilience.Azure.Policies;

public static class BlobPolicy
{
    public static readonly AsyncRetryPolicy asyncRetryPolicy =
        BasePolicy<RequestFailedException>.GetAsyncRetryPolicy(AzureBlobExceptionPredicate.ShouldRetryOn);
}