﻿using Microsoft.EntityFrameworkCore;
using OpenBaseNET.Domain.Entities;
using System.Reflection;

namespace OpenBaseNET.Infra.Data.Context;

public class OneBaseDataBaseContext(DbSession session) : DbContext
{
    public virtual required DbSet<Customer> Customers { get; set; }

    public DbSet<Customer> Customer {get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(session.Connection?.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

}