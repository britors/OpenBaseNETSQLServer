using OpenBaseNET.Infra.Resilience.Core.Pipelines;
using OpenBaseNET.Infra.Resilience.Http.ExceptionPredicate;
using Polly;

namespace OpenBaseNET.Infra.Resilience.Http.Pipelines;

public static class HttpClientePipeline
{
    public static readonly ResiliencePipeline AsyncRetryPipeline =
        BasePipeline<HttpRequestException>.GetAsyncRetryPipeline(HttpExceptionPredicate.ShouldRetryOn);
}