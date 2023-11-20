using System.Data;
using System.Data.Common;

namespace OpenBaseNET.Infra.Data.Context;

public sealed class DbSession : IDisposable
{
    public DbSession(DbConnection connection)
    {
        Connection = connection;
        Connection.Open();
    }

    public DbConnection? Connection { get; init; }
    public DbTransaction? Transaction { get; set; }

    public void Dispose()
    {
        Dispose(true);
    }

    private void Dispose(bool disposing)
    {
        if (!disposing) return;
        Transaction?.Dispose();
        if (Connection?.State != ConnectionState.Closed) Connection?.Close();
        Connection?.Dispose();
    }
}