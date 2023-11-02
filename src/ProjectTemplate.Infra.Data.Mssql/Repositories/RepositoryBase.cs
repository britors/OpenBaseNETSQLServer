using ConsoleTables;
using Microsoft.Extensions.Logging;
using ProjectTemplate.Domain.Context;
using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Infra.Data.Dapper.Mssql.Extension;
using ProjectTemplate.Infra.Data.EF.Mssql.Extension;
using ProjectTemplate.Infra.Mssql.Uow;
using System.Data;
using System.Linq.Expressions;

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
        return obj;
    }

    public async Task<int> AddReturningRecordsAffectsAsync(TEntity obj)
    {
        _dbContext.Set<TEntity>().Add(obj);
        return await _dbContext.SaveChangesAsyncWtithRetry();
    }

    public async Task<IEnumerable<TEntity>>
        FindAsync(Expression<Func<TEntity, bool>> predicate,
        params Expression<Func<TEntity, object>>[] includes)
        => await _dbContext.FindAsyncWith<TEntity>(predicate, includes);

    public async Task<TEntity?> GetByIdAsync<KeyType>(KeyType id)
        => await _dbContext.GetByIdAsyncWithRetry<TEntity, KeyType>(id);

    public async Task<bool> RemoveAsync(TEntity obj)
    {
        _dbContext.Set<TEntity>().Remove(obj);
        return await _dbContext.SaveChangesAsyncWtithRetry() > 0;
    }

    public async Task<bool> RemoveByIdAsync<KeyType>(KeyType id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is null) return false;

        _dbContext.Set<TEntity>().Remove(entity);
        return await _dbContext.SaveChangesAsyncWtithRetry() > 0;
    }

    public async Task<int> RemoveReturningRecordsAffectsAsync(TEntity obj)
    {
        _dbContext.Set<TEntity>().Remove(obj);
        return await _dbContext.SaveChangesAsyncWtithRetry();
    }

    public async Task<TEntity> UpdateAsync(TEntity obj)
    {
        _dbContext.Set<TEntity>().Update(obj);
        await _dbContext.SaveChangesAsyncWtithRetry();
        return obj;
    }

    public async Task<int> UpdateByIdReturningRecordsAffectsAsync<KeyType>(TEntity obj, KeyType id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null) return 0;

        _dbContext.Entry(entity).CurrentValues.SetValues(obj);
        return await _dbContext.SaveChangesAsyncWtithRetry();
    }

    public async Task<int> UpdateReturningRecordsAffectsAsync(TEntity obj)
    {
        _dbContext.Set<TEntity>().Update(obj);
        return await _dbContext.SaveChangesAsyncWtithRetry();
    }

    public async Task<int> ExecuteAsync(string sql, object? param = null)
    {
        if (_dbSession.Connection is null) throw new ArgumentException(nameof(_dbSession.Connection));
        _logger.LogInformation(sql);
        var result = await _dbSession.Connection.ExecuteAsyncWithRetry(sql: sql,
                                                                    parameters: param,
                                                                    commandType: CommandType.Text,
                                                                    transaction: _dbSession.Transaction);
        return result;
    }

    public async Task<IEnumerable<TResult>?> QueryAsync<TResult>(string query, object? param = null)
        where TResult : IEntityOrQueryResult
    {
        if (_dbSession.Connection is null) throw new ArgumentException(nameof(_dbSession.Connection));

        _logger.LogInformation(query);

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

        _logger.LogInformation(query);

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
        _logger.LogInformation(query);

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
}