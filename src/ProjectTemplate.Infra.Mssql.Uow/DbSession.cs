using System.Data;
using System.Data.Common;

namespace ProjectTemplate.Infra.Mssql.Uow;

public class DbSession : IDisposable
{
    public DbConnection? Connection { get; set; } = null;
    public DbTransaction? Transaction { get; set; } = null;

    public DbSession(DbConnection connection)
    {
        Connection = connection;
        Connection.Open();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            Transaction?.Dispose();
            if (Connection?.State != ConnectionState.Closed) Connection?.Close();
            Connection?.Dispose();
        }
    }
}