using System.Linq.Expressions;

namespace OpenBaseNET.Domain.Interfaces.Services;

public interface IDomainService<TEntity, in TKeyType> where TEntity : class
{
    Task<TEntity?> GetByIdAsync(TKeyType id);

    Task<IEnumerable<TEntity>>
        FindAsync(Expression<Func<TEntity, bool>>? predicate = null,
            bool pagination = false,
            int pageNumber = 1,
            int pageSize = 10,
            params Expression<Func<TEntity, object>>[] includes);

    Task<TEntity?> AddAsync(TEntity obj);

    Task<TEntity?> UpdateAsync(TEntity obj);

    Task<bool> RemoveAsync(TEntity obj);

    Task<bool> RemoveByIdAsync(TKeyType id);

    Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null);
}