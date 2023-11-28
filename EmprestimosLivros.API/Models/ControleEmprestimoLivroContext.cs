﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmprestimosLivros.API.Models;

public partial class ControleEmprestimoLivroContext : DbContext
{
    public ControleEmprestimoLivroContext(DbContextOptions<ControleEmprestimoLivroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Livro> Livros { get; set; }

    public virtual DbSet<LivroClienteEmprestimo> LivroClienteEmprestimos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3213E83F1A147619");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CliNumero).IsFixedLength();
            entity.Property(e => e.CliTelefoneCelular).IsFixedLength();
            entity.Property(e => e.CliTelefoneFixo).IsFixedLength();
        });

        modelBuilder.Entity<Livro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Livro__3213E83F5B89C2D9");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<LivroClienteEmprestimo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Livro_Cl__3213E83F5F2D81EF");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.LceIdClienteNavigation).WithMany(p => p.LivroClienteEmprestimos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Livro_Cli__LceId__45F365D3");

            entity.HasOne(d => d.LceIdLivroNavigation).WithMany(p => p.LivroClienteEmprestimos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Livro_Cli__LceId__46E78A0C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}