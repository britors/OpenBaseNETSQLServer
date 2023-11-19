using Microsoft.EntityFrameworkCore;
using OpenBaseNET.Domain.Entities;

namespace OpenBaseNET.Infra.Uow;

public class OneBaseDataBaseContext(DbSession session) : DbContext
{
    public virtual DbSet<Customer> Clientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(session.Connection?.ConnectionString);
    }
}