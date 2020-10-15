using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApi.Dominio.Models
{
    public class Escola
    {
        [Key]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string CodigoINEP { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        public List<Turma> Turmas { get; set; }

    }
}
