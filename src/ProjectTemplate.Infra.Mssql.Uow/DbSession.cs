using System.Data;
using System.Data.Common;

namespace ProjectTemplate.Infra.Mssql.Uow;

public sealed class DbSession : IDisposable
{
    public DbConnection? Connection { get; init; }
    public DbTransaction? Transaction { get; set; }

    public DbSession(DbConnection connection)
    {
        Connection = connection;
        Connection.Open();
    }

    public void Dispose()
    {
        Dispose(true);
    }

    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            Transaction?.Dispose();
            if (Connection?.State != ConnectionState.Closed) Connection?.Close();
            Connection?.Dispose();
        }
    }
}