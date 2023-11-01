using Polly.Retry;
using ProjectTemplate.Infra.Resilience.Core.Policies;
using ProjectTemplate.Infra.Resilience.Database.Mssql.ExceptionPredicate;
using System.Data.SqlClient;

namespace ProjectTemplate.Infra.Resilience.Database.Mssql.Policies;

public static class DatabasePolicy
{
    public static readonly AsyncRetryPolicy asyncRetryPolicy =
        BasePolicy<SqlException>.GetAsyncRetryPolicy(MssqlExceptionPredicate.ShouldRetryOn);
}