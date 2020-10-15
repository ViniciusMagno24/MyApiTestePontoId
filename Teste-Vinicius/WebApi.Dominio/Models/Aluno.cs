using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text;

namespace WebApi.Dominio.Models
{
    [Table("Alunos")]
    public class Aluno
    {
        [Key]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime DataNascimento { get; set; }

        [ForeignKey("Escolas")]
        public string CodigoEscolar { get; set; }
        [ForeignKey("Turmas")]
        public int TurmaId { get; set; }
    }
}
