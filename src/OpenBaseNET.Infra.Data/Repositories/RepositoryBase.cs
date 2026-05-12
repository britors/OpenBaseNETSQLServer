using OpenBaseNET.Domain.Interfaces.Repositories;
using OpenBaseNET.Infra.Dapper.Extension;
using OpenBaseNET.Infra.Data.Context;
using OpenBaseNET.Infra.EF.Extension;
using System.Data;
using System.Linq.Expressions;

namespace OpenBaseNET.Infra.Data.Repositories;

public abstract class RepositoryBase<TEntity>
    (
        DbSession dbSession,
        OneBaseDataBaseContext dbContext)
    : IRepositoryBase<TEntity>
    where TEntity : class
{
    public async Task<TEntity> AddAsync(TEntity obj, CancellationToken cancellationToken)
    {
        await dbContext.Set<TEntity>().AddAsync(obj, cancellationToken);
        await dbContext.SaveChangesAsyncWithRetry(cancellationToken);
        return obj;
    }

    public async Task<IEnumerable<TEntity>>
        FindAsync(CancellationToken cancellationToken,
            bool noTracking = false,
            Expression<Func<TEntity, bool>>? predicate = null,
            int? pageNumber = null,
            int? pageSize = null,
            params Expression<Func<TEntity, object>>[] includes)
    {

        var result = await dbContext.FindAsyncWithRetry(
            cancellationToken,
            noTracking,
            predicate,
            pageNumber,
            pageSize,
            includes);


        return result;
    }

    public async Task<TEntity?> GetByIdAsync<TKey>(TKey id, CancellationToken cancellationToken)
    {

        var result = await dbContext.GetByIdAsyncWithRetry<TEntity, TKey>(id, cancellationToken);
        return result;
    }

    public async Task<bool> RemoveAsync(TEntity obj, CancellationToken cancellationToken)
    {
        dbContext.Set<TEntity>().Remove(obj);
        return await dbContext.SaveChangesAsyncWithRetry(cancellationToken) > 0;
    }

    public async Task<bool> RemoveByIdAsync<TKey>(TKey id, CancellationToken cancellationToken)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        if (entity is null) return false;
        dbContext.Set<TEntity>().Remove(entity);
        return await dbContext.SaveChangesAsyncWithRetry(cancellationToken) > 0;
    }

    public async Task<TEntity> UpdateAsync(TEntity obj, CancellationToken cancellationToken)
    {
        dbContext.Set<TEntity>().Update(obj);
        await dbContext.SaveChangesAsyncWithRetry(cancellationToken);
        return obj;
    }

    public async Task<int> ExecuteAsync(string sql, CancellationToken cancellationToken, object? param = null)
    {
        if (dbSession.Connection is null) throw new ArgumentException(nameof(dbSession.Connection));
        var result = await dbSession.Connection.ExecuteAsyncWithRetry(
            cancellationToken,
            sql,
            parameters: param,
            commandType: CommandType.Text,
            transaction: dbSession.Transaction);

        return result;
    }

    public async Task<IEnumerable<TResult>?> QueryAsync<TResult>(string query, CancellationToken cancellationToken,
        object? param = null)
        where TResult : IEntityOrQueryResult
    {
        if (dbSession.Connection is null) throw new ArgumentException(nameof(dbSession.Connection));

        var result = await dbSession.Connection.QueryAsyncWithRetry<TResult>(
            cancellationToken,
            query,
            parameters: param,
            commandType: CommandType.Text,
            transaction: dbSession.Transaction);

        return result;
    }

    public async Task<TResult?> QueryFirstOrDefaultAsync<TResult>(string query, CancellationToken cancellationToken,
        object? param = null)
        where TResult : IEntityOrQueryResult
    {
        if (dbSession.Connection is null) throw new ArgumentException(nameof(dbSession.Connection));
        var result = await dbSession.Connection.QueryFirstOrDefaultAsyncWithRetry<TResult?>(
            cancellationToken,
            query,
            parameters: param,
            commandType: CommandType.Text,
            transaction: dbSession.Transaction);

        return result;
    }

    public async Task<TResult?> QuerySingleOrDefaultAsync<TResult>(string query,
        CancellationToken cancellationToken,
        object? param = null)
        where TResult : IEntityOrQueryResult
    {
        if (dbSession.Connection is null) throw new ArgumentException(nameof(dbSession.Connection));

        var result = await dbSession.Connection.QuerySingleOrDefaultAsyncWithRetry<TResult?>(
            cancellationToken,
            query,
            parameters: param,
            commandType: CommandType.Text,
            transaction: dbSession.Transaction);

        return result;
    }

    public Task<int> CountAsync(CancellationToken cancellationToken,
        Expression<Func<TEntity, bool>>? predicate = null)
            => dbContext.CountAsyncWithRetry(cancellationToken, predicate);
}
