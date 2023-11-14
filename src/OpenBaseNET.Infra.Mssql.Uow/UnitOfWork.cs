using Microsoft.EntityFrameworkCore;
using OpenBaseNET.Infra.Mssql.Uow.Interfaces;

namespace OpenBaseNET.Infra.Mssql.Uow;

public sealed class UnitOfWork(DbSession session, ProjectDbContext context) : IUnitOfWork, IDisposable
{
    public void Dispose()
    {
        Dispose(true);
    }

    public async Task BeginTransactionAsync()
    {
        if (session.Connection is null) throw new ArgumentException(nameof(session.Connection));
        session.Transaction = await session.Connection.BeginTransactionAsync();
        await context.Database.UseTransactionAsync(session.Transaction);
    }

    public async Task CommitAsync()
    {
        if (session.Transaction is null) throw new ArgumentException(nameof(session.Transaction));
        await session.Transaction.CommitAsync();
    }

    public async Task RoolbackAsync()
    {
        if (session.Transaction is null) throw new ArgumentException(nameof(session.Transaction));
        await session.Transaction.RollbackAsync();
    }

    private void Dispose(bool disposing)
    {
        if (disposing)
            session.Transaction?.Dispose();
    }
}