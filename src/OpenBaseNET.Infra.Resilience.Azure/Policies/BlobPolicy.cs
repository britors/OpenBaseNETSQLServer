using Azure;
using OpenBaseNET.Infra.Resilience.Azure.ExceptionPredicate;
using Polly.Retry;
using OpenBaseNET.Infra.Resilience.Core.Policies;

namespace OpenBaseNET.Infra.Resilience.Azure.Policies;

public static class BlobPolicy
{
    public static readonly AsyncRetryPolicy asyncRetryPolicy =
        BasePolicy<RequestFailedException>.GetAsyncRetryPolicy(AzureBlobExceptionPredicate.ShouldRetryOn);
}