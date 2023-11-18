using System.Data;
using System.Linq.Expressions;
using System.Text.Json;
using ConsoleTables;
using Microsoft.Extensions.Logging;
using OpenBaseNET.Domain.Interfaces.Repositories;
using OpenBaseNET.Infra.Data.Dapper.Mssql.Extension;
using OpenBaseNET.Infra.Data.EF.Mssql.Extension;
using OpenBaseNET.Infra.Mssql.Uow;

namespace OpenBaseNET.Infra.Data.Mssql.Repositories;

public abstract class RepositoryBase<TEntity>(DbSession dbSession,
        ProjectDbContext dbContext,
        ILogger<RepositoryBase<TEntity>> logger)
    : IRepositoryBase<TEntity>
    where TEntity : class
{
    public async Task<TEntity> AddAsync(TEntity obj, CancellationToken cancellationToken)
    {
        dbContext.Set<TEntity>().Add(obj);
        await dbContext.SaveChangesAsyncWtithRetry(cancellationToken);
        logger.LogInformation($"Adicionado {JsonSerializer.Serialize(obj)} em {typeof(TEntity).Name}");
        var list = new List<TEntity>
        {
            obj
        };
        logger.LogInformation("Valores:");
        ConsoleTable.From(list).Write();
        return obj;
    }

    public async Task<IEnumerable<TEntity>>
        FindAsync(CancellationToken cancellationToken, Expression<Func<TEntity, bool>>? predicate = null,
            int? pageNumber = null,
            int? pageSize = null,
            params Expression<Func<TEntity, object>>[] includes)
    {
        var result = await dbContext.FindAsyncWithRetry(
            cancellationToken,
            predicate,
            pageNumber,
            pageSize,
            includes);
        logger.LogInformation($"Buscando em {typeof(TEntity).Name} usando : {predicate}");
        logger.LogInformation("Resultado:");
        var findAsync = result.ToList();
        ConsoleTable.From(findAsync).Write();
        return findAsync;
    }

    public async Task<TEntity?> GetByIdAsync<TKey>(TKey id, CancellationToken cancellationToken)
    {
        var result = await dbContext.GetByIdAsyncWithRetry<TEntity, TKey>(id, cancellationToken);
        logger.LogInformation($"Buscar {typeof(TEntity).Name} por : {id}");
        if (result is null) return result;
        var list = new List<TEntity>
        {
            result
        };
        logger.LogInformation("Resultado:");
        ConsoleTable.From(list).Write();

        return result;
    }

    public async Task<bool> RemoveAsync(TEntity obj, CancellationToken cancellationToken)
    {
        dbContext.Set<TEntity>().Remove(obj);
        logger.LogInformation($"Removendo de : {typeof(TEntity).Name}");
        var list = new List<TEntity>
        {
            obj
        };
        ConsoleTable.From(list).Write();
        return await dbContext.SaveChangesAsyncWtithRetry(cancellationToken) > 0;
    }

    public async Task<bool> RemoveByIdAsync<TKey>(TKey id, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Removendo de : {typeof(TEntity).Name}");
        var entity = await GetByIdAsync(id, cancellationToken);
        if (entity is null) return false;
        dbContext.Set<TEntity>().Remove(entity);
        return await dbContext.SaveChangesAsyncWtithRetry(cancellationToken) > 0;
    }

    public async Task<TEntity> UpdateAsync(TEntity obj, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Atualizando {JsonSerializer.Serialize(obj)} em {typeof(TEntity).Name}");
        dbContext.Set<TEntity>().Update(obj);
        var list = new List<TEntity>
        {
            obj
        };
        logger.LogInformation("Valores:");
        ConsoleTable.From(list).Write();
        await dbContext.SaveChangesAsyncWtithRetry(cancellationToken);
        return obj;
    }

    public async Task<int> ExecuteAsync(string sql, CancellationToken cancellationToken, object? param = null)
    {
        if (dbSession.Connection is null) throw new ArgumentException(nameof(dbSession.Connection));
        logger.LogInformation($"Executando o comando {DapperHelper.BuildCommandWithParams(param, sql)}");
        var result = await dbSession.Connection.ExecuteAsyncWithRetry(
            cancellationToken,
            sql,
            parameters: param,
            commandType: CommandType.Text,
            transaction: dbSession.Transaction);
        logger.LogInformation($"Registros afetados: {result}");
        return result;
    }

    public async Task<IEnumerable<TResult>?> QueryAsync<TResult>(string query, CancellationToken cancellationToken,
        object? param = null)
        where TResult : IEntityOrQueryResult
    {
        if (dbSession.Connection is null) throw new ArgumentException(nameof(dbSession.Connection));

        logger.LogInformation($"Executando a query:\n {DapperHelper.BuildCommandWithParams(param, query)}");

        var result = await dbSession.Connection.QueryAsyncWithRetry<TResult>(
            cancellationToken,
            query,
            parameters: param,
            commandType: CommandType.Text,
            transaction: dbSession.Transaction);
        logger.LogInformation("Resultado:");
        var entityOrQueryResults = result.ToList();
        ConsoleTable.From(entityOrQueryResults).Write();
        return entityOrQueryResults;
    }

    public async Task<TResult?> QueryFirstOrDefaultAsync<TResult>(string query, CancellationToken cancellationToken,
        object? param = null)
        where TResult : IEntityOrQueryResult
    {
        if (dbSession.Connection is null) throw new ArgumentException(nameof(dbSession.Connection));

        logger.LogInformation($"Executando a query :\n {DapperHelper.BuildCommandWithParams(param, query)}");

        var result = await dbSession.Connection.QueryFirstOrDefaultAsyncWithRetry<TResult?>(
            cancellationToken,
            query,
            parameters: param,
            commandType: CommandType.Text,
            transaction: dbSession.Transaction);

        logger.LogInformation("Resultado:");
        if (result is null) return result;
        var list = new List<TResult>
        {
            result
        };
        ConsoleTable.From(list).Write();

        return result;
    }

    public async Task<TResult?> QuerySingleOrDefaultAsync<TResult>(string query,
        CancellationToken cancellationToken,
        object? param = null)
        where TResult : IEntityOrQueryResult
    {
        if (dbSession.Connection is null) throw new ArgumentException(nameof(dbSession.Connection));
        logger.LogInformation($"Executando a query :\n {DapperHelper.BuildCommandWithParams(param, query)}");

        var result = await dbSession.Connection.QuerySingleOrDefaultAsyncWithRetry<TResult?>(
            cancellationToken,
            query,
            parameters: param,
            commandType: CommandType.Text,
            transaction: dbSession.Transaction);

        logger.LogInformation("Resultado:");
        if (result is null) return result;
        var list = new List<TResult>
        {
            result
        };
        ConsoleTable.From(list).Write();
        return result;
    }

    public Task<int> CountAsync(CancellationToken cancellationToken, Expression<Func<TEntity, bool>>? predicate = null)
    {
        return dbContext.CountAsyncWithRetry(cancellationToken, predicate);
    }
}