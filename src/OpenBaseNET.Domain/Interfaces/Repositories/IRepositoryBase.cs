using System.Linq.Expressions;

namespace OpenBaseNET.Domain.Interfaces.Repositories;

public interface IRepositoryBase<TEntity> where TEntity : class
{
    Task<TEntity> AddAsync(TEntity obj);

    Task<TEntity?> GetByIdAsync<TKey>(TKey id);

    Task<IEnumerable<TEntity>>
        FindAsync(Expression<Func<TEntity, bool>>? predicate = null,
            int? pageNumber = null,
            int? pageSize = null,
            params Expression<Func<TEntity, object>>[] includes);

    Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null);

    Task<TEntity> UpdateAsync(TEntity obj);

    Task<bool> RemoveAsync(TEntity obj);

    Task<bool> RemoveByIdAsync<TKey>(TKey id);

    Task<int> ExecuteAsync(string sql, object? param = null);

    Task<TResult?> QuerySingleOrDefaultAsync<TResult>(string query, object? param = null)
        where TResult : IEntityOrQueryResult;

    Task<TResult?> QueryFirstOrDefaultAsync<TResult>(string query, object? param = null)
        where TResult : IEntityOrQueryResult;

    Task<IEnumerable<TResult>?> QueryAsync<TResult>(string query, object? param = null)
        where TResult : IEntityOrQueryResult;
}