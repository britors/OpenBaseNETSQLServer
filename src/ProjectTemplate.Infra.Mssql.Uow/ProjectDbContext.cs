using Microsoft.EntityFrameworkCore;
using ProjectTemplate.Domain.Entities;

namespace ProjectTemplate.Infra.Mssql.Uow;

public class ProjectDbContext : DbContext
{
    private readonly DbSession _session;

    public ProjectDbContext(DbSession session) : base()
        => _session = session;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(_session.Connection?.ConnectionString);
    }

    public DbSet<Cliente> Clientes { get; set; }
}