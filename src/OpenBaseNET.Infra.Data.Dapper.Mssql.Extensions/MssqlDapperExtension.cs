using System.Data;
using Dapper;
using OpenBaseNET.Infra.Resilience.Database.Mssql.Policies;

namespace OpenBaseNET.Infra.Data.Dapper.Mssql.Extension;

public static class MssqlDapperExtension
{
    public static async Task<int> ExecuteAsyncWithRetry(
        this IDbConnection connection,
        string? sql = null,
        IDbTransaction? transaction = null,
        int? commandTimeout = null,
        CommandType? commandType = null,
        object? parameters = null)
    {
        if (connection is null)
            throw new ArgumentNullException(nameof(connection));

        if (string.IsNullOrWhiteSpace(sql))
            throw new ArgumentException($"'{nameof(sql)}' cannot be null or empty.", nameof(sql));

        return await DatabasePolicy.asyncRetryPolicy.ExecuteAsync(async ()
            => await connection.ExecuteAsync(sql,
                parameters,
                transaction,
                commandTimeout,
                commandType));
    }

    public static async Task<IEnumerable<T>> QueryAsyncWithRetry<T>(
        this IDbConnection connection,
        string? sql = null,
        IDbTransaction? transaction = null,
        int? commandTimeout = null,
        CommandType? commandType = null,
        object? parameters = null)
    {
        if (connection is null)
            throw new ArgumentNullException(nameof(connection));

        if (string.IsNullOrWhiteSpace(sql))
            throw new ArgumentException($"'{nameof(sql)}' cannot be null or empty.", nameof(sql));

        return await DatabasePolicy.asyncRetryPolicy.ExecuteAsync(async () =>
            await connection.QueryAsync<T>(sql, parameters, transaction, commandTimeout, commandType));
    }

    public static async Task<T?> ExecuteScalarAsyncWithRetry<T>(
        this IDbConnection connection,
        string? sql = null,
        IDbTransaction? transaction = null,
        int? commandTimeout = null,
        CommandType? commandType = null,
        object? parameters = null)
    {
        if (connection is null)
            throw new ArgumentNullException(nameof(connection));

        if (string.IsNullOrWhiteSpace(sql))
            throw new ArgumentException($"'{nameof(sql)}' cannot be null or empty.", nameof(sql));

        return await DatabasePolicy.asyncRetryPolicy.ExecuteAsync(async () =>
            await connection.ExecuteScalarAsync<T>(sql,
                parameters,
                transaction,
                commandTimeout,
                commandType));
    }

    public static async Task<T?> QueryFirstOrDefaultAsyncWithRetry<T>(
        this IDbConnection connection,
        string? sql = null,
        IDbTransaction? transaction = null,
        int? commandTimeout = null,
        CommandType? commandType = null,
        object? parameters = null)
    {
        if (connection is null)
            throw new ArgumentNullException(nameof(connection));

        if (string.IsNullOrWhiteSpace(sql))
            throw new ArgumentException($"'{nameof(sql)}' cannot be null or empty.", nameof(sql));

        return await DatabasePolicy.asyncRetryPolicy.ExecuteAsync(async () =>
            await connection.QueryFirstOrDefaultAsync<T>(sql,
                parameters,
                transaction,
                commandTimeout,
                commandType));
    }

    public static async Task<T?> QuerySingleOrDefaultAsyncWithRetry<T>(
        this IDbConnection connection,
        string? sql = null,
        IDbTransaction? transaction = null,
        int? commandTimeout = null,
        CommandType? commandType = null,
        object? parameters = null)
    {
        if (connection is null)
            throw new ArgumentNullException(nameof(connection));

        if (string.IsNullOrWhiteSpace(sql))
            throw new ArgumentException($"'{nameof(sql)}' cannot be null or empty.", nameof(sql));

        return await DatabasePolicy.asyncRetryPolicy.ExecuteAsync(async () =>
            await connection.QuerySingleOrDefaultAsync<T>(sql,
                parameters,
                transaction,
                commandTimeout,
                commandType));
    }
}