using Microsoft.Extensions.Logging;
using OpenBaseNET.Domain.Interfaces.Repositories;
using OpenBaseNET.Infra.Dapper.Extension;
using OpenBaseNET.Infra.Data.Context;
using OpenBaseNET.Infra.EF.Extension;
using System.Data;
using System.Linq.Expressions;
using System.Text.Json;

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
        logger.LogInformation(
            "Adicionando {Name} com valores {Value}",
            typeof(TEntity).Name,
            JsonSerializer.Serialize(obj));

        await dbContext.Set<TEntity>().AddAsync(obj);
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
        logger.LogInformation(
            "Buscando por {Name} com os seguintes filtros: {Predicate} e includes {Includes}",
             typeof(TEntity).Name,
             predicate,
             JsonSerializer.Serialize(includes));

        var result = await dbContext.FindAsyncWithRetry(
            cancellationToken,
            predicate,
            pageNumber,
            pageSize,
            includes);

        logger.LogInformation(
            "Resultado da busca por {Name} com os seguintes filtros: {Predicate} e includes {Includes} foi {Result}",
            typeof(TEntity).Name,
            predicate,
            includes,
            result);

        return result;
    }

    public async Task<TEntity?> GetByIdAsync<TKey>(TKey id, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Buscando por {Name} com id {Id}",
            typeof(TEntity).Name,
            id);

        var result = await dbContext.GetByIdAsyncWithRetry<TEntity, TKey>(id, cancellationToken);

        logger.LogInformation(
            "Resultado da busca por {Name} com id {Id} foi {Result}",
            typeof(TEntity).Name,
            id,
            result);

        return result;
    }

    public async Task<bool> RemoveAsync(TEntity obj, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Removendo {Name} com valores {Values}",
            typeof(TEntity).Name,
            JsonSerializer.Serialize(obj));

        dbContext.Set<TEntity>().Remove(obj);
        
        return await dbContext.SaveChangesAsyncWtithRetry(cancellationToken) > 0;
    }

    public async Task<bool> RemoveByIdAsync<TKey>(TKey id, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Removendo {Name} com id {Id}",
            typeof(TEntity).Name,
            id);
        
        var entity = await GetByIdAsync(id, cancellationToken);

        if (entity is null) return false;

        dbContext.Set<TEntity>().Remove(entity);

        return await dbContext.SaveChangesAsyncWtithRetry(cancellationToken) > 0;
    }

    public async Task<TEntity> UpdateAsync(TEntity obj, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Atualizando {Name} com valores {Value}",
            typeof(TEntity).Name,
            JsonSerializer.Serialize(obj));
        
        dbContext.Set<TEntity>().Update(obj);
        
        await dbContext.SaveChangesAsyncWtithRetry(cancellationToken);
        
        return obj;
    }

    public async Task<int> ExecuteAsync(string sql, CancellationToken cancellationToken, object? param = null)
    {
        if (dbSession.Connection is null) throw new ArgumentException(nameof(dbSession.Connection));

        logger.LogInformation(
            "Executando comando {Sql}",
            sql);
        
        var result = await dbSession.Connection.ExecuteAsyncWithRetry(
            cancellationToken,
            sql,
            parameters: param,
            commandType: CommandType.Text,
            transaction: dbSession.Transaction);
        
        logger.LogInformation(
            "Resultado da execução do comando {Sql} foi {Result}",
            sql,
            result
            );
        
        return result;
    }

    public async Task<IEnumerable<TResult>?> QueryAsync<TResult>(string query, CancellationToken cancellationToken,
        object? param = null)
        where TResult : IEntityOrQueryResult
    {
        if (dbSession.Connection is null) throw new ArgumentException(nameof(dbSession.Connection));

        logger.LogInformation(
            "Executando query {Query}",
            query);
        
        var result = await dbSession.Connection.QueryAsyncWithRetry<TResult>(
            cancellationToken,
            query,
            parameters: param,
            commandType: CommandType.Text,
            transaction: dbSession.Transaction);

        logger.LogInformation(
            "Resultado da execução da query {Query} foi {Result}",
            query,
            JsonSerializer.Serialize(result));

        return result;
    }

    public async Task<TResult?> QueryFirstOrDefaultAsync<TResult>(string query, CancellationToken cancellationToken,
        object? param = null)
        where TResult : IEntityOrQueryResult
    {
        if (dbSession.Connection is null) throw new ArgumentException(nameof(dbSession.Connection));
        
        logger.LogInformation(
            "Executando query {Query}",
            query);

        var result = await dbSession.Connection.QueryFirstOrDefaultAsyncWithRetry<TResult?>(
            cancellationToken,
            query,
            parameters: param,
            commandType: CommandType.Text,
            transaction: dbSession.Transaction);

        logger.LogInformation(
            "Resultado da execução da query {Query} foi {Result}",
            query,
            JsonSerializer.Serialize(result));
        
        return result;
    }

    public async Task<TResult?> QuerySingleOrDefaultAsync<TResult>(string query,
        CancellationToken cancellationToken,
        object? param = null)
        where TResult : IEntityOrQueryResult
    {
        if (dbSession.Connection is null) throw new ArgumentException(nameof(dbSession.Connection));

        logger.LogInformation(
            "Executando query {Query}",
            query);
        
        var result = await dbSession.Connection.QuerySingleOrDefaultAsyncWithRetry<TResult?>(
            cancellationToken,
            query,
            parameters: param,
            commandType: CommandType.Text,
            transaction: dbSession.Transaction);
        
        logger.LogInformation(
            "Resultado da execução da query {Query} foi {Reult}",
            query,
            JsonSerializer.Serialize(result));
        
        return result;
    }

    public Task<int> CountAsync(CancellationToken cancellationToken,
        Expression<Func<TEntity, bool>>? predicate = null)
            => dbContext.CountAsyncWithRetry(cancellationToken, predicate);
}