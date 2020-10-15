using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApi.Dominio.Models
{
    public class Turma
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Serie { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Turno { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string CodigoEscolar { get; set; }

        public List<Aluno> Alunos { get; set; }
    }
}
