using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProjectTemplate.Infra.Resilience.Database.Mssql.Policies;

namespace ProjectTemplate.Infra.Data.EF.Mssql.Extension;

public static class MssqlEFExtension
{
    public static async Task<int> SaveChangesAsyncWtithRetry(this DbContext context)
    {
        if (context is null)
            throw new ArgumentNullException(nameof(context));

        return await DatabasePolicy.asyncRetryPolicy.ExecuteAsync(async () =>
            await context.SaveChangesAsync());
    }

    public static async Task<TEntity?>
        GetByIdAsyncWithRetry<TEntity, KeyType>(this DbContext context, KeyType id) where TEntity : class
    {
        if (context is null)
            throw new ArgumentNullException(nameof(context));

        return await DatabasePolicy.asyncRetryPolicy.ExecuteAsync(async () =>
            await context.Set<TEntity>().FindAsync(id));
    }

    public static async Task<IEnumerable<TEntity>> FindAsyncWithRetry<TEntity>(
        this DbContext context,
        Expression<Func<TEntity, bool>>? predicate = null,
        bool pagination = false,
        int pageNumber = 1,
        int pageSize = 10,
        params Expression<Func<TEntity, object>>[] includes) where TEntity : class
    {
        if (context is null)
            throw new ArgumentNullException(nameof(context));

        return await DatabasePolicy.asyncRetryPolicy.ExecuteAsync(async () =>
        {
            var query = context.Set<TEntity>().AsQueryable();

            query = includes.Aggregate(query, (current, include)
                => current.Include(include));

            if (predicate is not null)
                query = query.Where(predicate);

            if (pagination) query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return await query.ToListAsync();
        });
    }

    public static async Task<int> CountAsyncWithRetry<TEntity>(
        this DbContext context,
        Expression<Func<TEntity, bool>>? predicate = null) where TEntity : class
    {
        if (context is null)
            throw new ArgumentNullException(nameof(context));

        return await DatabasePolicy.asyncRetryPolicy.ExecuteAsync(async () =>
        {
            var query = context.Set<TEntity>().AsQueryable();

            if (predicate is not null)
                query = query.Where(predicate);

            return await query.CountAsync();
        });
    }
}