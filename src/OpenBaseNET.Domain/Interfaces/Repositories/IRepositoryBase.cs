using System.Linq.Expressions;

namespace OpenBaseNET.Domain.Interfaces.Repositories;

public interface IRepositoryBase<TEntity> where TEntity : class
{
    Task<TEntity> AddAsync(TEntity obj, CancellationToken cancellationToken);

    Task<TEntity?> GetByIdAsync<TKey>(TKey id, CancellationToken cancellationToken);

    Task<IEnumerable<TEntity>>
        FindAsync(
            CancellationToken cancellationToken,
            Expression<Func<TEntity, bool>>? predicate = null,
            int? pageNumber = null,
            int? pageSize = null,
            params Expression<Func<TEntity, object>>[] includes);

    Task<int> CountAsync(CancellationToken cancellationToken, Expression<Func<TEntity, bool>>? predicate = null);

    Task<TEntity> UpdateAsync(TEntity obj, CancellationToken cancellationToken);

    Task<bool> RemoveAsync(TEntity obj, CancellationToken cancellationToken);

    Task<bool> RemoveByIdAsync<TKey>(TKey id, CancellationToken cancellationToken);

    Task<int> ExecuteAsync(string sql, CancellationToken cancellationToken, object? param = null);

    Task<TResult?> QuerySingleOrDefaultAsync<TResult>(
        string query,
        CancellationToken cancellationToken,
        object? param = null)
        where TResult : IEntityOrQueryResult;

    Task<TResult?> QueryFirstOrDefaultAsync<TResult>(
        string query,
        CancellationToken cancellationToken,
        object? param = null)
        where TResult : IEntityOrQueryResult;

    Task<IEnumerable<TResult>?> QueryAsync<TResult>(
        string query,
        CancellationToken cancellationToken,
        object? param = null)
        where TResult : IEntityOrQueryResult;
}