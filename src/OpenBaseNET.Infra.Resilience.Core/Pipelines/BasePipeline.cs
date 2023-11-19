using OpenBaseNET.Infra.Resilience.Core.ExceptionPredicate;
using Polly;
using Polly.Retry;
using System.ComponentModel;

namespace OpenBaseNET.Infra.Resilience.Core.Pipelines;

public static class BasePipeline<TException> where TException : Exception
{
    public static ResiliencePipeline GetAsyncRetryPipeline(Func<TException, bool> exceptionPredicate)
    {
        return new ResiliencePipelineBuilder()
            .AddRetry(new RetryStrategyOptions
            {
                ShouldHandle = new PredicateBuilder()
                    .Handle(exceptionPredicate)
                    .Handle<TimeoutException>(TimeoutExceptionPredicate.ShouldRetryOn)
                    .Handle<Win32Exception>(Win32ExceptionPredicate.ShouldRetryOn),
                Delay = TimeSpan.FromSeconds(30),
                MaxRetryAttempts = 5,
                BackoffType = DelayBackoffType.Constant
            })
            .Build();
    }
}