using Microsoft.EntityFrameworkCore;
using OpenBaseNET.Domain.Entities;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using OpenBaseNET.Infra.Settings.ConnectionStrings;

namespace OpenBaseNET.Infra.Data.Context;

public class OneBaseDataBaseContext(IConfiguration configuration) : DbContext
{
    public virtual required DbSet<Customer> Customers { get; set; }

    public DbSet<Customer> Customer {get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var cn = (configuration.GetConnectionString(OneBaseConnectionStrings.OpenBaseSqlServer));
        
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(cn);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

}