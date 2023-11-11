using Microsoft.EntityFrameworkCore;
using OpenBaseNET.Infra.Mssql.Uow.Interfaces;

namespace OpenBaseNET.Infra.Mssql.Uow;

public sealed class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ProjectDbContext _context;
    private readonly DbSession _session;

    public UnitOfWork(DbSession session, ProjectDbContext context)
    {
        _session = session;
        _context = context;
    }

    public void Dispose()
    {
        Dispose(true);
    }

    public async Task BeginTransactionAsync()
    {
        if (_session.Connection is null) throw new ArgumentException(nameof(_session.Connection));
        var session = _session;
        session.Transaction = await _session.Connection.BeginTransactionAsync();
        await _context.Database.UseTransactionAsync(_session.Transaction);
    }

    public async Task CommitAsync()
    {
        if (_session.Transaction is null) throw new ArgumentException(nameof(_session.Transaction));
        await _session.Transaction.CommitAsync();
    }

    public async Task RoolbackAsync()
    {
        if (_session.Transaction is null) throw new ArgumentException(nameof(_session.Transaction));
        await _session.Transaction.RollbackAsync();
    }

    private void Dispose(bool disposing)
    {
        if (disposing)
            _session.Transaction?.Dispose();
    }
}