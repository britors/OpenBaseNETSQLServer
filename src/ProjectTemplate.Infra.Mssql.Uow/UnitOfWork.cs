using Microsoft.EntityFrameworkCore;
using ProjectTemplate.Infra.Mssql.Uow.Interfaces;

namespace ProjectTemplate.Infra.Mssql.Uow;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly DbSession _session;
    private readonly ProjectDbContext _context;

    public UnitOfWork(DbSession session, ProjectDbContext context)
    {
        _session = session;
        _context = context;
    }

    public async Task BeginTransactionAsync()
    {
        if (_session.Connection is null) throw new ArgumentException(nameof(_session.Connection));
        DbSession session = _session;
        session.Transaction = await _session.Connection.BeginTransactionAsync();
        _context.Database.UseTransaction(_session.Transaction);
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

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
            _session.Transaction?.Dispose();
    }
}