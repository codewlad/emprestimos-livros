using System;
using System.Collections.Generic;

namespace EmprestimosLivros.Domain.Entities;

public partial class LivroClienteEmprestimo
{
    public int Id { get; set; }

    public int LceIdCliente { get; set; }

    public int LceIdLivro { get; set; }

    public DateTime LceDataEmprestimo { get; set; }

    public DateTime LceDataEntrega { get; set; }

    public bool LceEntregue { get; set; }

    public virtual Cliente LceIdClienteNavigation { get; set; } = null!;

    public virtual Livro LceIdLivroNavigation { get; set; } = null!;
}
