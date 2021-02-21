using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Dtos
{
    public class EnderecoDto
    {
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Rua { get; set; }
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public Guid ClienteId { get; set; }
    }
}