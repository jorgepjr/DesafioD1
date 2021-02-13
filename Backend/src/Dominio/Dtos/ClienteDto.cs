using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Dtos
{
    public class ClienteDto
    {
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Cpf { get; set; }
        
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public DateTime DataDeNascimento { get; set; }
    }
}