using Azure;
using OpenBaseNET.Infra.Resilience.Azure.ExceptionPredicate;
using OpenBaseNET.Infra.Resilience.Core.Pipelines;
using Polly;

namespace OpenBaseNET.Infra.Resilience.Azure.Pipelines;

public static class AzureStorePipeline
{
    public static readonly ResiliencePipeline AsyncRetryPipeline =
        BasePipeline<RequestFailedException>.GetAsyncRetryPipeline(AzureStorageExceptionPredicate.ShouldRetryOn);
}