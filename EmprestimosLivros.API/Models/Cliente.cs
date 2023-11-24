﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmprestimosLivros.API.Models;

[Table("Cliente")]
public partial class Cliente
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("cliCPF")]
    [StringLength(14)]
    [Unicode(false)]
    public string CliCpf { get; set; }

    [Required]
    [Column("cliNome")]
    [StringLength(200)]
    [Unicode(false)]
    public string CliNome { get; set; }

    [Required]
    [Column("cliEndereco")]
    [StringLength(200)]
    [Unicode(false)]
    public string CliEndereco { get; set; }

    [Required]
    [Column("cliCidade")]
    [StringLength(100)]
    [Unicode(false)]
    public string CliCidade { get; set; }

    [Required]
    [Column("cliBairro")]
    [StringLength(100)]
    [Unicode(false)]
    public string CliBairro { get; set; }

    [Required]
    [Column("cliNumero")]
    [StringLength(50)]
    public string CliNumero { get; set; }

    [Required]
    [Column("cliTelefoneCelular")]
    [StringLength(14)]
    public string CliTelefoneCelular { get; set; }

    [Required]
    [Column("cliTelefoneFixo")]
    [StringLength(13)]
    public string CliTelefoneFixo { get; set; }

    [InverseProperty("LceIdClienteNavigation")]
    public virtual ICollection<LivroClienteEmprestimo> LivroClienteEmprestimos { get; set; } = new List<LivroClienteEmprestimo>();
}