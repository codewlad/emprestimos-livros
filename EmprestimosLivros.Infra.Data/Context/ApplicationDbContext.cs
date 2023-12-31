﻿using EmprestimosLivros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimosLivros.Infra.Data.Context;

public class ApplicationDbContext : DbContext
{
    protected ApplicationDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Emprestimo> Emprestimo { get; set; }
    public DbSet<Livro> Livro { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
