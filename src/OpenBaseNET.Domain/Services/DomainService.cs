using OpenBaseNET.Domain.Interfaces.Repositories;
using OpenBaseNET.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace OpenBaseNET.Domain.Services;

public abstract class DomainService<TEntity, TKeyType>
    (IRepositoryBase<TEntity> repository) : IDomainService<TEntity, TKeyType>
    where TEntity : class
{
    public async Task<TEntity?> AddAsync(TEntity obj, CancellationToken cancellationToken)
    {
        return await repository.AddAsync(obj, cancellationToken);
    }

    public async Task<bool> RemoveAsync(TEntity obj, CancellationToken cancellationToken)
    {
        return await repository.RemoveAsync(obj, cancellationToken);
    }

    public async Task<bool> RemoveByIdAsync(TKeyType id, CancellationToken cancellationToken)
    {
        return await repository.RemoveByIdAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<TEntity>>
        FindAsync(
            CancellationToken cancellationToken,
            Expression<Func<TEntity, bool>>? predicate = null,
            int? pageNumber = null,
            int? pageSize = null,
            params Expression<Func<TEntity, object>>[] includes)
    {
        return await repository.FindAsync(cancellationToken, predicate, pageNumber, pageSize, includes);
    }

    public async Task<TEntity?> GetByIdAsync(TKeyType id, CancellationToken cancellationToken)
    {
        return await repository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<TEntity?> UpdateAsync(TEntity obj, CancellationToken cancellationToken)
    {
        return await repository.UpdateAsync(obj, cancellationToken);
    }

    public async Task<int> CountAsync(CancellationToken cancellationToken,
        Expression<Func<TEntity, bool>>? predicate = null)
    {
        return await repository.CountAsync(cancellationToken, predicate);
    }
}