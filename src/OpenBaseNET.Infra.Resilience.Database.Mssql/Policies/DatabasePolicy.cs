using System.Data.SqlClient;
using Polly.Retry;
using OpenBaseNET.Infra.Resilience.Core.Policies;
using OpenBaseNET.Infra.Resilience.Database.Mssql.ExceptionPredicate;

namespace OpenBaseNET.Infra.Resilience.Database.Mssql.Policies;

public static class DatabasePolicy
{
    public static readonly AsyncRetryPolicy asyncRetryPolicy =
        BasePolicy<SqlException>.GetAsyncRetryPolicy(MssqlExceptionPredicate.ShouldRetryOn);
}