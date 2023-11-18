using System.Linq.Expressions;

namespace OpenBaseNET.Domain.Interfaces.Services;

public interface IDomainService<TEntity, in TKeyType> where TEntity : class
{
    Task<TEntity?> GetByIdAsync(TKeyType id, CancellationToken cancellationToken);

    Task<IEnumerable<TEntity>>
        FindAsync(
            CancellationToken cancellationToken,
            Expression<Func<TEntity, bool>>? predicate = null,
            int? pageNumber = null,
            int? pageSize = null,
            params Expression<Func<TEntity, object>>[] includes);

    Task<TEntity?> AddAsync(TEntity obj, CancellationToken cancellationToken);

    Task<TEntity?> UpdateAsync(TEntity obj, CancellationToken cancellationToken);

    Task<bool> RemoveAsync(TEntity obj, CancellationToken cancellationToken);

    Task<bool> RemoveByIdAsync(TKeyType id, CancellationToken cancellationToken);

    Task<int> CountAsync(CancellationToken cancellationToken, Expression<Func<TEntity, bool>>? predicate = null);
}