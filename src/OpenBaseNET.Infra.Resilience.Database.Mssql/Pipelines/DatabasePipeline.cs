using System.Data.SqlClient;
using OpenBaseNET.Infra.Resilience.Core.Pipelines;
using OpenBaseNET.Infra.Resilience.Database.Mssql.ExceptionPredicate;
using Polly;

namespace OpenBaseNET.Infra.Resilience.Database.Mssql.Pipelines;

public static class DatabasePipeline
{
    public static readonly ResiliencePipeline AsyncRetryPipeline =
        BasePipeline<SqlException>.GetAsyncRetryPipeline(MssqlExceptionPredicate.ShouldRetryOn);
}