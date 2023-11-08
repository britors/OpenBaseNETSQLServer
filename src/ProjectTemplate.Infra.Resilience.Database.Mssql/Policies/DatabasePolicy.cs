using System.Data.SqlClient;
using Polly.Retry;
using ProjectTemplate.Infra.Resilience.Core.Policies;
using ProjectTemplate.Infra.Resilience.Database.Mssql.ExceptionPredicate;

namespace ProjectTemplate.Infra.Resilience.Database.Mssql.Policies;

public static class DatabasePolicy
{
    public static readonly AsyncRetryPolicy asyncRetryPolicy =
        BasePolicy<SqlException>.GetAsyncRetryPolicy(MssqlExceptionPredicate.ShouldRetryOn);
}