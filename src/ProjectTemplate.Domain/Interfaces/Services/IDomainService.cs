using System.Linq.Expressions;

namespace ProjectTemplate.Domain.Interfaces.Services;

public interface IDomainService<TEntity, TKeyType> where TEntity : class
{
    Task<TEntity?> GetByIdAsync(TKeyType Id);

    Task<IEnumerable<TEntity>>
    FindAsync(Expression<Func<TEntity, bool>> predicate,
        bool pagination = false,
        int pageNumber = 1,
        int pageSize = 10,
        params Expression<Func<TEntity, object>>[] includes);

    Task<TEntity?> AddAsync(TEntity obj);

    Task<TEntity?> UpdateAsync(TEntity obj);

    Task<bool> RemoveAsync(TEntity obj);

    Task<bool> RemoveByIdAsync(TKeyType Id);
}