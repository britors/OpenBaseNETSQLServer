using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Retry;
using ProjectTemplate.Infra.Resilience.Core.ExceptionPredicate;
using System.ComponentModel;

namespace ProjectTemplate.Infra.Resilience.Core.Policies
{
    public static class BasePolicy<TException> where TException : Exception
    {
        private static TimeSpan GetMaxDelay() => TimeSpan.FromSeconds(30);

        private static IEnumerable<TimeSpan> RetryTimes() =>
            Backoff.DecorrelatedJitterBackoffV2(
                medianFirstRetryDelay: TimeSpan.FromSeconds(1),
                retryCount: 5,
                fastFirst: true)
            .Select(s => TimeSpan.FromTicks(Math.Min(s.Ticks, GetMaxDelay().Ticks)));

        public static AsyncRetryPolicy GetAsyncRetryPolicy(Func<TException, bool> exceptionPredicate)
            => Policy
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