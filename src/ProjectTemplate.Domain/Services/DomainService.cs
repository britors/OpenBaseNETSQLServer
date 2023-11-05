using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace ProjectTemplate.Domain.Services;

public abstract class DomainService<TEntity, TKeyType> : IDomainService<TEntity, TKeyType> where TEntity : class
{
    protected readonly IRepositoryBase<TEntity> _repository;

    protected DomainService(IRepositoryBase<TEntity> repository) => _repository = repository;

    public async Task<TEntity?> AddAsync(TEntity obj)
        => await _repository.AddAsync(obj);

    public async Task<bool> RemoveAsync(TEntity obj)
        => await _repository.RemoveAsync(obj);

    public async Task<bool> RemoveByIdAsync(TKeyType Id)
        => await _repository.RemoveByIdAsync(Id);

    public async Task<IEnumerable<TEntity>>
        FindAsync(Expression<Func<TEntity, bool>> predicate,
        params Expression<Func<TEntity, object>>[] includes)
        => await _repository.FindAsync(predicate, includes);

    public async Task<TEntity?> GetByIdAsync(TKeyType Id)
        => await _repository.GetByIdAsync(Id);

    public async Task<TEntity?> UpdateAsync(TEntity obj)
        => await _repository.UpdateAsync(obj);
}