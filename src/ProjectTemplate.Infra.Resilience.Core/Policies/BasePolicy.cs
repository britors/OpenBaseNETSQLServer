using System.ComponentModel;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Retry;
using ProjectTemplate.Infra.Resilience.Core.ExceptionPredicate;

namespace ProjectTemplate.Infra.Resilience.Core.Policies;

public static class BasePolicy<TException> where TException : Exception
{
    private static TimeSpan GetMaxDelay()
    {
        return TimeSpan.FromSeconds(30);
    }

    private static IEnumerable<TimeSpan> RetryTimes()
    {
        return Backoff.DecorrelatedJitterBackoffV2(
                TimeSpan.FromSeconds(1),
                5,
                fastFirst: true)
            .Select(s => TimeSpan.FromTicks(Math.Min(s.Ticks, GetMaxDelay().Ticks)));
    }

    public static AsyncRetryPolicy GetAsyncRetryPolicy(Func<TException, bool> exceptionPredicate)
    {
        return Policy
            .Handle(exceptionPredicate)
            .Or<TimeoutException>(TimeoutExceptionPredicate.ShouldRetryOn)
            .OrInner<Win32Exception>(Win32ExceptionPredicate.ShouldRetryOn)
            .WaitAndRetryAsync(RetryTimes(),
                (exception, timeSpan, retryCount, context) =>
                {
                    Console.WriteLine(
                        $@"Retry {retryCount} of {context.PolicyKey} at {context.OperationKey},due to: {exception}.");
                });
    }
}