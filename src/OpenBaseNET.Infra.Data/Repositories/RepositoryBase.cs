using OpenBaseNET.Domain.Interfaces.Repositories;
using OpenBaseNET.Infra.Data.Context;
using OpenBaseNET.Infra.EF.Extension;
using System.Data;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using OpenBaseNET.Infra.Dapper.Extension;

namespace OpenBaseNET.Infra.Data.Repositories;

public abstract class RepositoryBase<TEntity>
    (
        DbSession dbSession,
        ILogger<RepositoryBase<TEntity>> logger,
        OneBaseDataBaseContext dbContext)
    : IRepositoryBase<TEntity>
    where TEntity : class
{
    public async Task<TEntity> AddAsync(TEntity obj, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Adicionando {typeof(TEntity).Name} com valores {JsonSerializer.Serialize(obj)}");
        dbContext.Set<TEntity>().Add(obj);
        await dbContext.SaveChangesAsyncWtithRetry(cancellationToken);
        return obj;
    }

    public async Task<IEnumerable<TEntity>>
        FindAsync(CancellationToken cancellationToken,
            Expression<Func<TEntity, bool>>? predicate = null,
            int? pageNumber = null,
            int? pageSize = null,
            params Expression<Func<TEntity, object>>[] includes)
    {
        logger.LogInformation($"Buscando por {typeof(TEntity).Name} com os seguintes filtros: {predicate} e includes {JsonSerializer.Serialize(includes)}");
        var result = await dbContext.FindAsyncWithRetry(
            cancellationToken,
            predicate,
            pageNumber,
            pageSize,
            includes);
        logger.LogInformation($"Resultado da busca por {typeof(TEntity).Name} com os seguintes filtros: {predicate} e includes {JsonSerializer.Serialize(includes)} foi {JsonSerializer.Serialize(result)}");
        return result;
    }

    public async Task<TEntity?> GetByIdAsync<TKey>(TKey id, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Buscando por {typeof(TEntity).Name} com id {id}");
        var result = await dbContext.GetByIdAsyncWithRetry<TEntity, TKey>(id, cancellationToken);
        logger.LogInformation($"Resultado da busca por {typeof(TEntity).Name} com id {id} foi {result}");
        return result;
    }

    public async Task<bool> RemoveAsync(TEntity obj, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Removendo {typeof(TEntity).Name} com valores {JsonSerializer.Serialize(obj)}");
        dbContext.Set<TEntity>().Remove(obj);
        return await dbContext.SaveChangesAsyncWtithRetry(cancellationToken) > 0;
    }

    public async Task<bool> RemoveByIdAsync<TKey>(TKey id, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Removendo {typeof(TEntity).Name} com id {id}");
        var entity = await GetByIdAsync(id, cancellationToken);
        if (entity is null) return false;
        dbContext.Set<TEntity>().Remove(entity);
        return await dbContext.SaveChangesAsyncWtithRetry(cancellationToken) > 0;
    }

    public async Task<TEntity> UpdateAsync(TEntity obj, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Atualizando {typeof(TEntity).Name} com valores {JsonSerializer.Serialize(obj)}");
        dbContext.Set<TEntity>().Update(obj);
        await dbContext.SaveChangesAsyncWtithRetry(cancellationToken);
        return obj;
    }

    public async Task<int> ExecuteAsync(string sql, CancellationToken cancellationToken, object? param = null)
    {
        if (dbSession.Connection is null) throw new ArgumentException(nameof(dbSession.Connection));
        logger.LogInformation($"Executando comando {sql}");
        var result = await dbSession.Connection.ExecuteAsyncWithRetry(
            cancellationToken,
            sql,
            parameters: param,
            commandType: CommandType.Text,
            transaction: dbSession.Transaction);
        logger.LogInformation($"Resultado da execução do comando {sql} foi {result}");
        return result;
    }

    public async Task<IEnumerable<TResult>?> QueryAsync<TResult>(string query, CancellationToken cancellationToken,
        object? param = null)
        where TResult : IEntityOrQueryResult
    {
        if (dbSession.Connection is null) throw new ArgumentException(nameof(dbSession.Connection));
        logger.LogInformation($"Executando query {query}");
        var result = await dbSession.Connection.QueryAsyncWithRetry<TResult>(
            cancellationToken,
            query,
            parameters: param,
            commandType: CommandType.Text,
            transaction: dbSession.Transaction);

        logger.LogInformation($"Resultado da execução da query {query} foi {JsonSerializer.Serialize(result)}");
        return result;
    }

    public async Task<TResult?> QueryFirstOrDefaultAsync<TResult>(string query, CancellationToken cancellationToken,
        object? param = null)
        where TResult : IEntityOrQueryResult
    {
        if (dbSession.Connection is null) throw new ArgumentException(nameof(dbSession.Connection));
        logger.LogInformation($"Executando query {query}");
        var result = await dbSession.Connection.QueryFirstOrDefaultAsyncWithRetry<TResult?>(
            cancellationToken,
            query,
            parameters: param,
            commandType: CommandType.Text,
            transaction: dbSession.Transaction);
        logger.LogInformation($"Resultado da execução da query {query} foi {JsonSerializer.Serialize(result)}");
        return result;
    }

    public async Task<TResult?> QuerySingleOrDefaultAsync<TResult>(string query,
        CancellationToken cancellationToken,
        object? param = null)
        where TResult : IEntityOrQueryResult
    {
        if (dbSession.Connection is null) throw new ArgumentException(nameof(dbSession.Connection));
        logger.LogInformation($"Executando query {query}");
        var result = await dbSession.Connection.QuerySingleOrDefaultAsyncWithRetry<TResult?>(
            cancellationToken,
            query,
            parameters: param,
            commandType: CommandType.Text,
            transaction: dbSession.Transaction);
        logger.LogInformation($"Resultado da execução da query {query} foi {JsonSerializer.Serialize(result)}");
        return result;
    }

    public Task<int> CountAsync(CancellationToken cancellationToken,
        Expression<Func<TEntity, bool>>? predicate = null)
        => dbContext.CountAsyncWithRetry(cancellationToken, predicate);
}