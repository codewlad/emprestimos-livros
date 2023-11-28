using EmprestimosLivros.API.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace EmprestimosLivros.API.DTOs
{
    public class ClienteDTO
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [IgnoreDataMember]
        public int Id { get; set; }

        [Required]
        [StringLength(11)]
        [MinLength(14, ErrorMessage = "O CPF deve ter, no mínimo, 14 caracteres.")]
        [Unicode(false)]
        public string CliCpf { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "O Nome deve ter, no máximo, 200 caracteres.")]
        [Unicode(false)]
        public string CliNome { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "O Endereço deve ter, no máximo, 200 caracteres.")]
        [Unicode(false)]
        public string CliEndereco { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A Cidade deve ter, no máximo, 100 caracteres.")]
        [Unicode(false)]
        public string CliCidade { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O Bairro deve ter, no máximo, 100 caracteres.")]
        [Unicode(false)]
        public string CliBairro { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "O Número deve ter, no máximo, 50 caracteres.")]
        public string CliNumero { get; set; }

        [Required]
        [StringLength(14, ErrorMessage = "O Número do celular deve ter, no mínimo, 14 caracteres.")]
        public string CliTelefoneCelular { get; set; }

        [Required]
        [StringLength(13, ErrorMessage = "O Número do telefone deve ter, no mínimo, 13 caracteres.")]
        public string CliTelefoneFixo { get; set; }
    }
}
