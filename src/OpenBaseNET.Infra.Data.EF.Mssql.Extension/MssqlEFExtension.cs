using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OpenBaseNET.Infra.Resilience.Database.Mssql.Pipelines;

namespace OpenBaseNET.Infra.Data.EF.Mssql.Extension;

public static class MssqlEfExtension
{
    public static async Task<int> SaveChangesAsyncWtithRetry(this DbContext context)
    {
        if (context is null)
            throw new ArgumentNullException(nameof(context));
        
        return await DatabasePipeline.AsyncRetryPipeline.ExecuteAsync(async token =>
            await context.SaveChangesAsync(token));
    }

    public static async Task<TEntity?>
        GetByIdAsyncWithRetry<TEntity, TKey>(this DbContext context, TKey id) where TEntity : class
    {
        if (context is null)
            throw new ArgumentNullException(nameof(context));

        return await DatabasePipeline.AsyncRetryPipeline.ExecuteAsync(
            async token =>
            {
                if(id is null) return null;
                return await context.Set<TEntity>().FindAsync(new object[] { id }, token);
            });
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

        return await DatabasePipeline.AsyncRetryPipeline.ExecuteAsync(
            async token =>
            {
                var query = context.Set<TEntity>().AsQueryable();

                foreach (var include in includes)
                {
                    query = query.Include(include);
                }

                if (predicate is not null)
                    query = query.Where(predicate);

                if (pagination)
                    query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

                return await query.ToListAsync(token);
            }, 
            CancellationToken.None);
    }


    public static async Task<int> CountAsyncWithRetry<TEntity>(
        this DbContext context,
        Expression<Func<TEntity, bool>>? predicate = null) where TEntity : class
    {
        if (context is null)
            throw new ArgumentNullException(nameof(context));

        return await DatabasePipeline.AsyncRetryPipeline.ExecuteAsync(
            async token =>
            {
                var query = context.Set<TEntity>().AsQueryable();

                if (predicate is not null)
                    query = query.Where(predicate);

                return await query.CountAsync(token);
            },
            CancellationToken.None);
    }

}