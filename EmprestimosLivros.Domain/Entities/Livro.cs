﻿using EmprestimosLivros.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimosLivros.Domain.Entities;

public class Livro
{
    public int Id { get; private set; }
    public string LivroNome { get; private set; }
    public string LivroAutor { get; private set; }
    public string LivroEditora { get; private set; }
    public DateTime LivroAnoPublicacao { get; private set; }
    public string LivroEdicao { get; private set; }

    public ICollection<Emprestimo> Emprestimos { get; set; }

    public Livro(int id, string livroNome, string livroAutor, string livroEditora, DateTime livroAnoPublicacao, string livroEdicao)
    {
        DomainExceptionValidation.When(Id < 0, "O Id deve ser positivo.");
        ValidateDomain(livroNome, livroAutor, livroEditora, livroAnoPublicacao, livroEdicao);
        Id = id;
    }

    public Livro(string livroNome, string livroAutor, string livroEditora, DateTime livroAnoPublicacao, string livroEdicao)
    {
        ValidateDomain(livroNome, livroAutor, livroEditora, livroAnoPublicacao, livroEdicao);
    }

    public void Update(string livroNome, string livroAutor, string livroEditora, DateTime livroAnoPublicacao, string livroEdicao)
    {
        ValidateDomain(livroNome, livroAutor, livroEditora, livroAnoPublicacao, livroEdicao);
    }

    public void ValidateDomain(string livroNome, string livroAutor, string livroEditora, DateTime livroAnoPublicacao, string livroEdicao)
    {
        DomainExceptionValidation.When(livroNome.Length > 50, "O Nome do livro deve ter, no máximo, 50 caracteres.");
        DomainExceptionValidation.When(livroAutor.Length > 200, "O Autor do livro deve ter, no máximo, 200 caracteres.");
        DomainExceptionValidation.When(livroEditora.Length > 50, "O nome da editora deve ter, no máximo, 50 caracteres.");
        DomainExceptionValidation.When(livroEdicao.Length > 50, "A edição do livro deve ter, no máximo, 50 caracteres.");

        LivroNome = livroNome;
        LivroAutor = livroAutor;
        LivroEditora = livroEditora;
        LivroAnoPublicacao = livroAnoPublicacao;
        LivroEdicao = livroEdicao;
    }
}
