using Microsoft.EntityFrameworkCore;
using OpenBaseNET.Domain.Entities;

namespace OpenBaseNET.Infra.Mssql.Uow;

public class ProjectDbContext(DbSession session) : DbContext
{
    public virtual required DbSet<Customer> Clientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(session.Connection?.ConnectionString);
    }
}