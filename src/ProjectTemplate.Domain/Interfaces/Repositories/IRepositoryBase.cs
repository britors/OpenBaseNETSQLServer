using System.Linq.Expressions;

namespace ProjectTemplate.Domain.Interfaces.Repositories;

public partial interface IRepositoryBase<TEntity> where TEntity : class
{
    Task<TEntity> AddAsync(TEntity obj);

    Task<TEntity?> GetByIdAsync<KeyType>(KeyType id);

    Task<IEnumerable<TEntity>>
        FindAsync(Expression<Func<TEntity, bool>> predicate,
        params Expression<Func<TEntity, object>>[] includes);

    Task<TEntity> UpdateAsync(TEntity obj);

    Task<bool> RemoveAsync(TEntity obj);

    Task<bool> RemoveByIdAsync<KeyType>(KeyType id);

    Task<int> ExecuteAsync(string sql, object? param = null);

    Task<TResult?> QuerySingleOrDefaultAsync<TResult>(string query, object? param = null)
        where TResult : IEntityOrQueryResult;

    Task<TResult?> QueryFirstOrDefaultAsync<TResult>(string query, object? param = null)
        where TResult : IEntityOrQueryResult;

    Task<IEnumerable<TResult>?> QueryAsync<TResult>(string query, object? param = null)
        where TResult : IEntityOrQueryResult;
}