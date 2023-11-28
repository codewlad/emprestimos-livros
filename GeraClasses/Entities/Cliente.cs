using System;
using System.Collections.Generic;

namespace EmprestimosLivros.Domain.Entities;

public partial class Cliente
{
    public int Id { get; set; }

    public string CliCpf { get; set; } = null!;

    public string CliNome { get; set; } = null!;

    public string CliEndereco { get; set; } = null!;

    public string CliCidade { get; set; } = null!;

    public string CliBairro { get; set; } = null!;

    public string CliNumero { get; set; } = null!;

    public string CliTelefoneCelular { get; set; } = null!;

    public string CliTelefoneFixo { get; set; } = null!;

    public virtual ICollection<LivroClienteEmprestimo> LivroClienteEmprestimos { get; set; } = new List<LivroClienteEmprestimo>();
}
