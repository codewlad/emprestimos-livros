using System;
using System.Collections.Generic;

namespace EmprestimosLivros.Domain.Entities;

public partial class Livro
{
    public int Id { get; set; }

    public string LivroNome { get; set; } = null!;

    public string LivroAutor { get; set; } = null!;

    public string LivroEditora { get; set; } = null!;

    public DateTime LivroAnoPublicacao { get; set; }

    public string LivroEdicao { get; set; } = null!;

    public virtual ICollection<LivroClienteEmprestimo> LivroClienteEmprestimos { get; set; } = new List<LivroClienteEmprestimo>();
}
