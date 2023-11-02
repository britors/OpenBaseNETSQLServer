using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Infra.Data.Dapper.Mssql.Extension;
using ProjectTemplate.Infra.Data.EF.Mssql.Extension;
using ProjectTemplate.Infra.Mssql.Uow;
using System.Data;
using System.Linq.Expressions;

namespace ProjectTemplate.Infra.Data.Mssql.Repositories;

public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{
    protected readonly DbSession _session;
    protected readonly ProjectDbContext _context;

    protected RepositoryBase(DbSession session, ProjectDbContext Context)
    {
        _session = session;
        _context = Context;
    }

    public async Task<TEntity> AddAsync(TEntity obj)
    {
        _context.Set<TEntity>().Add(obj);
        await _context.SaveChangesAsyncWtithRetry();
        return obj;
    }

    public async Task<int> AddReturningRecordsAffectsAsync(TEntity obj)
    {
        _context.Set<TEntity>().Add(obj);
        return await _context.SaveChangesAsyncWtithRetry();
    }

    public async Task<IEnumerable<TEntity>>
        FindAsync(Expression<Func<TEntity, bool>> predicate,
        params Expression<Func<TEntity, object>>[] includes)
        => await _context.FindAsyncWith<TEntity>(predicate, includes);

    public async Task<TEntity?> GetByIdAsync<KeyType>(KeyType id)
        => await _context.GetByIdAsyncWithRetry<TEntity, KeyType>(id);

    public async Task<bool> RemoveAsync(TEntity obj)
    {
        _context.Set<TEntity>().Remove(obj);
        return await _context.SaveChangesAsyncWtithRetry() > 0;
    }

    public async Task<bool> RemoveByIdAsync<KeyType>(KeyType id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is null) return false;

        _context.Set<TEntity>().Remove(entity);
        return await _context.SaveChangesAsyncWtithRetry() > 0;
    }

    public async Task<int> RemoveReturningRecordsAffectsAsync(TEntity obj)
    {
        _context.Set<TEntity>().Remove(obj);
        return await _context.SaveChangesAsyncWtithRetry();
    }

    public async Task<TEntity> UpdateAsync(TEntity obj)
    {
        _context.Set<TEntity>().Update(obj);
        await _context.SaveChangesAsyncWtithRetry();
        return obj;
    }

    public async Task<int> UpdateByIdReturningRecordsAffectsAsync<KeyType>(TEntity obj, KeyType id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null) return 0;

        _context.Entry(entity).CurrentValues.SetValues(obj);
        return await _context.SaveChangesAsyncWtithRetry();
    }

    public async Task<int> UpdateReturningRecordsAffectsAsync(TEntity obj)
    {
        _context.Set<TEntity>().Update(obj);
        return await _context.SaveChangesAsyncWtithRetry();
    }

    public async Task<int> ExecuteAsync(string sql, object? param = null)
    {
        if (_session.Connection is null) throw new ArgumentException(nameof(_session.Connection));
        var result = await _session.Connection.ExecuteAsyncWithRetry(sql: sql,
                                                                    parameters: param,
                                                                    commandType: CommandType.Text,
                                                                    transaction: _session.Transaction);
        return result;
    }

    public async Task<IEnumerable<TResult>?> QueryAsync<TResult>(string query, object? param = null)
        where TResult : IEntityOrQueryResult
    {
        if (_session.Connection is null) throw new ArgumentException(nameof(_session.Connection));
        var result = await _session.Connection.QueryAsyncWithRetry<TResult>(sql: query,
                                                                                 parameters: param,
                                                                                 commandType: CommandType.Text,
                                                                                 transaction: _session.Transaction);
        return result;
    }

    public async Task<TResult?> QueryFirstOrDefaultAsync<TResult>(string query, object? param = null)
        where TResult : IEntityOrQueryResult
    {
        if (_session.Connection is null) throw new ArgumentException(nameof(_session.Connection));
        var result = await _session.Connection.QueryFirstOrDefaultAsyncWithRetry<TResult?>(sql: query,
                                                                                 parameters: param,
                                                                                 commandType: CommandType.Text,
                                                                                 transaction: _session.Transaction);
        return result;
    }

    public async Task<TResult?> QuerySingleOrDefaultAsync<TResult>(string query, object? param = null)
        where TResult : IEntityOrQueryResult
    {
        if (_session.Connection is null) throw new ArgumentException(nameof(_session.Connection));
        var result = await _session.Connection.QuerySingleOrDefaultAsyncWithRetry<TResult?>(sql: query,
                                                                                 parameters: param,
                                                                                 commandType: CommandType.Text,
                                                                                 transaction: _session.Transaction);
        return result;
    }
}