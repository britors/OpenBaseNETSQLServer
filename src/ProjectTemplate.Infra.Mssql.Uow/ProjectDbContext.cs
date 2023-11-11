using Microsoft.EntityFrameworkCore;
using OpenBaseNET.Domain.Entities;

namespace ProjectTemplate.Infra.Mssql.Uow;

public class ProjectDbContext : DbContext
{
    private readonly DbSession _session;

    public ProjectDbContext(DbSession session)
    {
        _session = session;
    }

    public virtual required DbSet<Cliente> Clientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(_session.Connection?.ConnectionString);
    }
}