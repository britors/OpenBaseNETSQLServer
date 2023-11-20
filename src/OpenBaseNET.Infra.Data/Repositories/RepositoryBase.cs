using Microsoft.Extensions.Logging;
using OpenBaseNET.Domain.Interfaces.Repositories;
using OpenBaseNET.Infra.Data.Context;
using OpenBaseNET.Infra.EF.Extension;
using System.Data;
using System.Linq.Expressions;
using System.Text.Json;
using OpenBaseNET.Infra.Data.Dapper.Extension;

namespace OpenBaseNET.Infra.Data.Repositories;

public abstract class RepositoryBase<TEntity>(DbSession dbSession,
        OneBaseDataBaseContext dbContext,
        ILogger<RepositoryBase<TEntity>> logger)
    : IRepositoryBase<TEntity>
    where TEntity : class
{
    public async Task<TEntity> AddAsync(TEntity obj, CancellationToken cancellationToken)
    {
        dbContext.Set<TEntity>().Add(obj);
        await dbContext.SaveChangesAsyncWtithRetry(cancellationToken);
        return obj;
    }

    public async Task<IEnumerable<TEntity>>
        FindAsync(CancellationToken cancellationToken,
            Expression<Func<TEntity, bool>>? predicate = null,
            int? pageNumber = null,
            int? pageSize = null,
            params Expression<Func<TEntity, object>>[] includes) =>
        await dbContext.FindAsyncWithRetry(
            cancellationToken,
            predicate,
            pageNumber,
            pageSize,
            includes);

    public async Task<TEntity?> GetByIdAsync<TKey>(TKey id, CancellationToken cancellationToken) 
        => await dbContext.GetByIdAsyncWithRetry<TEntity, TKey>(id, cancellationToken);

    public async Task<bool> RemoveAsync(TEntity obj, CancellationToken cancellationToken)
    {
        dbContext.Set<TEntity>().Remove(obj);
        return await dbContext.SaveChangesAsyncWtithRetry(cancellationToken) > 0;
    }

    public async Task<bool> RemoveByIdAsync<TKey>(TKey id, CancellationToken cancellationToken)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        if (entity is null) return false;
        dbContext.Set<TEntity>().Remove(entity);
        return await dbContext.SaveChangesAsyncWtithRetry(cancellationToken) > 0;
    }

    public async Task<TEntity> UpdateAsync(TEntity obj, CancellationToken cancellationToken)
    {
        dbContext.Set<TEntity>().Update(obj);
        await dbContext.SaveChangesAsyncWtithRetry(cancellationToken);
        return obj;
    }

    public async Task<int> ExecuteAsync(string sql, CancellationToken cancellationToken, object? param = null)
    {
        if (dbSession.Connection is null) throw new ArgumentException(nameof(dbSession.Connection));
        return await dbSession.Connection.ExecuteAsyncWithRetry(
            cancellationToken,
            sql,
            parameters: param,
            commandType: CommandType.Text,
            transaction: dbSession.Transaction);
    }

    public async Task<IEnumerable<TResult>?> QueryAsync<TResult>(string query, CancellationToken cancellationToken,
        object? param = null)
        where TResult : IEntityOrQueryResult
    {
        if (dbSession.Connection is null) throw new ArgumentException(nameof(dbSession.Connection));
        return await dbSession.Connection.QueryAsyncWithRetry<TResult>(
            cancellationToken,
            query,
            parameters: param,
            commandType: CommandType.Text,
            transaction: dbSession.Transaction);
    }

    public async Task<TResult?> QueryFirstOrDefaultAsync<TResult>(string query, CancellationToken cancellationToken,
        object? param = null)
        where TResult : IEntityOrQueryResult
    {
        if (dbSession.Connection is null) throw new ArgumentException(nameof(dbSession.Connection));
        return await dbSession.Connection.QueryFirstOrDefaultAsyncWithRetry<TResult?>(
            cancellationToken,
            query,
            parameters: param,
            commandType: CommandType.Text,
            transaction: dbSession.Transaction);
    }

    public async Task<TResult?> QuerySingleOrDefaultAsync<TResult>(string query,
        CancellationToken cancellationToken,
        object? param = null)
        where TResult : IEntityOrQueryResult
    {
        if (dbSession.Connection is null) throw new ArgumentException(nameof(dbSession.Connection));
        return await dbSession.Connection.QuerySingleOrDefaultAsyncWithRetry<TResult?>(
            cancellationToken,
            query,
            parameters: param,
            commandType: CommandType.Text,
            transaction: dbSession.Transaction);
    }

    public Task<int> CountAsync(CancellationToken cancellationToken, Expression<Func<TEntity, bool>>? predicate = null) 
        => dbContext.CountAsyncWithRetry(cancellationToken, predicate);
}