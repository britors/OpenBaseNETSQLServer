using Microsoft.EntityFrameworkCore;
using OpenBaseNET.Infra.Resilience.Database.Mssql.Pipelines;
using System.Linq.Expressions;

namespace OpenBaseNET.Infra.EF.Extension;

public static class EfExtension
{
    public static async Task<int> SaveChangesAsyncWtithRetry(this DbContext context,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(context);

        return await DatabasePipeline.AsyncRetryPipeline.ExecuteAsync(async token =>
                await context.SaveChangesAsync(token),
            cancellationToken);
    }

    public static async Task<TEntity?>
        GetByIdAsyncWithRetry<TEntity, TKey>(
            this DbContext context,
            TKey id,
            CancellationToken cancellationToken) where TEntity : class
    {
        ArgumentNullException.ThrowIfNull(context);

        return await DatabasePipeline.AsyncRetryPipeline.ExecuteAsync(
            async token =>
            {
                if (id is null) return null;
                return await context.Set<TEntity>().FindAsync(new object[] { id }, token);
            }, cancellationToken);
    }

    public static async Task<IEnumerable<TEntity>> FindAsyncWithRetry<TEntity>(
        this DbContext context,
        CancellationToken cancellationToken,
        bool noTracking = false,
        Expression<Func<TEntity, bool>>? predicate = null,
        int? pageNumber = null,
        int? pageSize = null,
        params Expression<Func<TEntity, object>>[] includes) where TEntity : class
    {
        ArgumentNullException.ThrowIfNull(context);

        return await DatabasePipeline.AsyncRetryPipeline.ExecuteAsync(
            async token =>
            {
                var query = context
                    .Set<TEntity>()
                    .AsQueryable();

                if (noTracking)
                    query = query.AsNoTracking();

                query = includes
                    .Aggregate(query, (current, include)
                        => current.Include(include));

                if (predicate is not null)
                    query = query.Where(predicate);

                if (pageNumber is not null && pageSize is not null)
                    query = query.Skip((pageNumber.Value - 1) * pageSize.Value).Take(pageSize.Value);

                return await query.ToListAsync(token);
            },
            cancellationToken);
    }

    public static async Task<int> CountAsyncWithRetry<TEntity>(
        this DbContext context,
        CancellationToken cancellationToken,
        Expression<Func<TEntity, bool>>? predicate = null) where TEntity : class
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(context);

        return await DatabasePipeline.AsyncRetryPipeline.ExecuteAsync(
            async token =>
            {
                var query = context.Set<TEntity>().AsQueryable();

                if (predicate is not null)
                    query = query.Where(predicate);

                return await query.CountAsync(token);
            },
            cancellationToken);
    }
}