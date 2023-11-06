using ConsoleTables;
using Microsoft.Extensions.Logging;
using ProjectTemplate.Domain.Context;
using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Infra.Data.Dapper.Mssql.Extension;
using ProjectTemplate.Infra.Data.EF.Mssql.Extension;
using ProjectTemplate.Infra.Mssql.Uow;
using System.Data;
using System.Linq.Expressions;
using System.Text.Json;

namespace ProjectTemplate.Infra.Data.Mssql.Repositories;

public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{
    protected readonly DbSession _dbSession;
    protected readonly ProjectDbContext _dbContext;
    protected readonly SessionContext _sessionContext;
    protected readonly ILogger<RepositoryBase<TEntity>> _logger;

    protected RepositoryBase(DbSession dbSession,
                            ProjectDbContext dbContext,
                            SessionContext sessionContext,
                            ILogger<RepositoryBase<TEntity>> Logger)
    {
        _dbSession = dbSession;
        _dbContext = dbContext;
        _sessionContext = sessionContext;
        _logger = Logger;
    }

    public async Task<TEntity> AddAsync(TEntity obj)
    {
        _dbContext.Set<TEntity>().Add(obj);
        await _dbContext.SaveChangesAsyncWtithRetry();
        _logger.LogInformation($"Adicionado {JsonSerializer.Serialize(obj)} em {typeof(TEntity).Name}");
        var list = new List<TEntity>
            {
                obj
            };
        _logger.LogInformation("Valores:");
        ConsoleTable.From(list).Write();
        return obj;
    }

    public async Task<IEnumerable<TEntity>>
        FindAsync(Expression<Func<TEntity, bool>>? predicate = null,
        bool pagination = false,
        int pageNumber = 1,
        int pageSize = 10,
        params Expression<Func<TEntity, object>>[] includes)
    {
        var result = await _dbContext.FindAsyncWithRetry(predicate, pagination, pageNumber, pageSize, includes);
        _logger.LogInformation($"Buscando em {typeof(TEntity).Name} usando : {predicate}");
        _logger.LogInformation("Resultado:");
        ConsoleTable.From(result).Write();
        return result;
    }

    public async Task<TEntity?> GetByIdAsync<KeyType>(KeyType id)
    {
        var result = await _dbContext.GetByIdAsyncWithRetry<TEntity, KeyType>(id);
        _logger.LogInformation($"Buscar {typeof(TEntity).Name} por : {id}");
        if (result is not null)
        {
            var list = new List<TEntity>
            {
                result
            };
            _logger.LogInformation("Resultado:");
            ConsoleTable.From(list).Write();
        }
        return result;
    }

    public async Task<bool> RemoveAsync(TEntity obj)
    {
        _dbContext.Set<TEntity>().Remove(obj);
        _logger.LogInformation($"Removendo de : {typeof(TEntity).Name}");
        var list = new List<TEntity>
            {
                obj
            };
        ConsoleTable.From(list).Write();
        return await _dbContext.SaveChangesAsyncWtithRetry() > 0;
    }

    public async Task<bool> RemoveByIdAsync<KeyType>(KeyType id)
    {
        _logger.LogInformation($"Removendo de : {typeof(TEntity).Name}");
        var entity = await GetByIdAsync(id);
        if (entity is null) return false;
        _dbContext.Set<TEntity>().Remove(entity);
        return await _dbContext.SaveChangesAsyncWtithRetry() > 0;
    }

    public async Task<TEntity> UpdateAsync(TEntity obj)
    {
        _logger.LogInformation($"Atualizando {JsonSerializer.Serialize(obj)} em {typeof(TEntity).Name}");
        _dbContext.Set<TEntity>().Update(obj);
        var list = new List<TEntity>
            {
                obj
            };
        _logger.LogInformation("Valores:");
        ConsoleTable.From(list).Write();
        await _dbContext.SaveChangesAsyncWtithRetry();
        return obj;
    }

    public async Task<int> ExecuteAsync(string sql, object? param = null)
    {
        if (_dbSession.Connection is null) throw new ArgumentException(nameof(_dbSession.Connection));
        _logger.LogInformation($"Executando o comando {sql}");
        var result = await _dbSession.Connection.ExecuteAsyncWithRetry(sql: sql,
                                                                    parameters: param,
                                                                    commandType: CommandType.Text,
                                                                    transaction: _dbSession.Transaction);
        _logger.LogInformation($"Registros afetados: {result}");
        return result;
    }

    public async Task<IEnumerable<TResult>?> QueryAsync<TResult>(string query, object? param = null)
        where TResult : IEntityOrQueryResult
    {
        if (_dbSession.Connection is null) throw new ArgumentException(nameof(_dbSession.Connection));

        _logger.LogInformation($"Executando a query:\n {query}");

        var result = await _dbSession.Connection.QueryAsyncWithRetry<TResult>(sql: query,
                                                                                 parameters: param,
                                                                                 commandType: CommandType.Text,
                                                                                 transaction: _dbSession.Transaction);
        _logger.LogInformation("Resultado:");
        ConsoleTable.From(result).Write();
        return result;
    }

    public async Task<TResult?> QueryFirstOrDefaultAsync<TResult>(string query, object? param = null)
        where TResult : IEntityOrQueryResult
    {
        if (_dbSession.Connection is null) throw new ArgumentException(nameof(_dbSession.Connection));

        _logger.LogInformation($"Executando a query :\n {query}");

        var result = await _dbSession.Connection.QueryFirstOrDefaultAsyncWithRetry<TResult?>(sql: query,
                                                                                 parameters: param,
                                                                                 commandType: CommandType.Text,
                                                                                 transaction: _dbSession.Transaction);

        _logger.LogInformation("Resultado:");
        if (result is not null)
        {
            var list = new List<TResult>
            {
                result
            };
            ConsoleTable.From(list).Write();
        }

        return result;
    }

    public async Task<TResult?> QuerySingleOrDefaultAsync<TResult>(string query, object? param = null)
        where TResult : IEntityOrQueryResult
    {
        if (_dbSession.Connection is null) throw new ArgumentException(nameof(_dbSession.Connection));
        _logger.LogInformation($"Executando a query :\n {query}");

        var result = await _dbSession.Connection.QuerySingleOrDefaultAsyncWithRetry<TResult?>(sql: query,
                                                                                 parameters: param,
                                                                                 commandType: CommandType.Text,
                                                                                 transaction: _dbSession.Transaction);

        _logger.LogInformation("Resultado:");
        if (result is not null)
        {
            var list = new List<TResult>
            {
                result
            };
            ConsoleTable.From(list).Write();
        }
        return result;
    }

    public Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null)
        => _dbContext.CountAsyncWithRetry(predicate);
}