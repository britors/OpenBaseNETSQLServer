using System.Linq.Expressions;
using OpenBaseNET.Domain.Interfaces.Repositories;
using OpenBaseNET.Domain.Interfaces.Services;

namespace OpenBaseNET.Domain.Services;

public abstract class DomainService<TEntity, TKeyType>
    (IRepositoryBase<TEntity> repository) : IDomainService<TEntity, TKeyType>
    where TEntity : class
{
    public async Task<TEntity?> AddAsync(TEntity obj)
    {
        return await repository.AddAsync(obj);
    }

    public async Task<bool> RemoveAsync(TEntity obj)
    {
        return await repository.RemoveAsync(obj);
    }

    public async Task<bool> RemoveByIdAsync(TKeyType id)
    {
        return await repository.RemoveByIdAsync(id);
    }

    public async Task<IEnumerable<TEntity>>
        FindAsync(Expression<Func<TEntity, bool>>? predicate = null,
            int? pageNumber = null,
            int? pageSize = null,
            params Expression<Func<TEntity, object>>[] includes)
    {
        return await repository.FindAsync(predicate, pageNumber, pageSize, includes);
    }

    public async Task<TEntity?> GetByIdAsync(TKeyType id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<TEntity?> UpdateAsync(TEntity obj)
    {
        return await repository.UpdateAsync(obj);
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
        return await repository.CountAsync(predicate);
    }
}