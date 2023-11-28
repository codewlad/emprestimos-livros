using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmprestimosLivros.Domain.Entities;

public partial class ControleEmprestimoLivroContext : DbContext
{
    public ControleEmprestimoLivroContext()
    {
    }

    public ControleEmprestimoLivroContext(DbContextOptions<ControleEmprestimoLivroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Livro> Livros { get; set; }

    public virtual DbSet<LivroClienteEmprestimo> LivroClienteEmprestimos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=TRIJAY;Database=ControleEmprestimoLivro;Trusted_Connection=True;Encrypt=False;User Id=sa;Password=SQL2208;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3213E83F1A147619");

            entity.ToTable("Cliente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CliBairro)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cliBairro");
            entity.Property(e => e.CliCidade)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cliCidade");
            entity.Property(e => e.CliCpf)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("cliCPF");
            entity.Property(e => e.CliEndereco)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("cliEndereco");
            entity.Property(e => e.CliNome)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("cliNome");
            entity.Property(e => e.CliNumero)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cliNumero");
            entity.Property(e => e.CliTelefoneCelular)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("cliTelefoneCelular");
            entity.Property(e => e.CliTelefoneFixo)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("cliTelefoneFixo");
        });

        modelBuilder.Entity<Livro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Livro__3213E83F5B89C2D9");

            entity.ToTable("Livro");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LivroAnoPublicacao)
                .HasColumnType("datetime")
                .HasColumnName("livroAnoPublicacao");
            entity.Property(e => e.LivroAutor)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("livroAutor");
            entity.Property(e => e.LivroEdicao)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("livroEdicao");
            entity.Property(e => e.LivroEditora)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("livroEditora");
            entity.Property(e => e.LivroNome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("livroNome");
        });

        modelBuilder.Entity<LivroClienteEmprestimo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Livro_Cl__3213E83F5F2D81EF");

            entity.ToTable("Livro_Cliente_Emprestimo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LceDataEmprestimo).HasColumnType("datetime");
            entity.Property(e => e.LceDataEntrega).HasColumnType("datetime");

            entity.HasOne(d => d.LceIdClienteNavigation).WithMany(p => p.LivroClienteEmprestimos)
                .HasForeignKey(d => d.LceIdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Livro_Cliente_Emprestimo_Cliente");

            entity.HasOne(d => d.LceIdLivroNavigation).WithMany(p => p.LivroClienteEmprestimos)
                .HasForeignKey(d => d.LceIdLivro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Livro_Cliente_Emprestimo_Livro");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
