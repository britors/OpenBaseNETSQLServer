using System.Data;
using Dapper;
using OpenBaseNET.Infra.Resilience.Database.Mssql.Pipelines;

namespace OpenBaseNET.Infra.Data.Dapper.Mssql.Extension;

public static class MssqlDapperExtension
{
    public static async Task<int> ExecuteAsyncWithRetry(
        this IDbConnection connection,
        CancellationToken cancellationToken,
        string? sql = null,
        IDbTransaction? transaction = null,
        int? commandTimeout = null,
        CommandType? commandType = null,
        object? parameters = null)
    {
        ArgumentNullException.ThrowIfNull(connection);

        if (string.IsNullOrWhiteSpace(sql))
            throw new ArgumentException($"'{nameof(sql)}' cannot be null or empty.", nameof(sql));

        return await DatabasePipeline.AsyncRetryPipeline.ExecuteAsync(
            async _ => await connection.ExecuteAsync(sql,
                parameters,
                transaction,
                commandTimeout,
                commandType),
            cancellationToken);
    }

    public static async Task<IEnumerable<T>> QueryAsyncWithRetry<T>(
        this IDbConnection connection,
        CancellationToken cancellationToken,
        string? sql = null,
        IDbTransaction? transaction = null,
        int? commandTimeout = null,
        CommandType? commandType = null,
        object? parameters = null)
    {
        ArgumentNullException.ThrowIfNull(connection);

        if (string.IsNullOrWhiteSpace(sql))
            throw new ArgumentException($"'{nameof(sql)}' cannot be null or empty.", nameof(sql));

        return await DatabasePipeline.AsyncRetryPipeline.ExecuteAsync(
            async _ => await connection.QueryAsync<T>(sql,
                parameters,
                transaction,
                commandTimeout,
                commandType),
            cancellationToken);
    }

    public static async Task<T?> QueryFirstOrDefaultAsyncWithRetry<T>(
        this IDbConnection connection,
        CancellationToken cancellationToken,
        string? sql = null,
        IDbTransaction? transaction = null,
        int? commandTimeout = null,
        CommandType? commandType = null,
        object? parameters = null)
    {
        ArgumentNullException.ThrowIfNull(connection);

        if (string.IsNullOrWhiteSpace(sql))
            throw new ArgumentException($"'{nameof(sql)}' cannot be null or empty.", nameof(sql));

        return await DatabasePipeline.AsyncRetryPipeline.ExecuteAsync(
            async _ => await connection.QueryFirstOrDefaultAsync<T>(sql,
                parameters,
                transaction,
                commandTimeout,
                commandType),
            cancellationToken);
    }

    public static async Task<T?> QuerySingleOrDefaultAsyncWithRetry<T>(
        this IDbConnection connection,
        CancellationToken cancellationToken,
        string? sql = null,
        IDbTransaction? transaction = null,
        int? commandTimeout = null,
        CommandType? commandType = null,
        object? parameters = null)
    {
        ArgumentNullException.ThrowIfNull(connection);

        if (string.IsNullOrWhiteSpace(sql))
            throw new ArgumentException($"'{nameof(sql)}' cannot be null or empty.", nameof(sql));

        return await DatabasePipeline.AsyncRetryPipeline.ExecuteAsync(
            async _ => await connection.QuerySingleOrDefaultAsync<T>(sql,
                parameters,
                transaction,
                commandTimeout,
                commandType),
            cancellationToken);
    }
}