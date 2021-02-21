using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace App.Models
{
    public class EnderecoViewModel
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
        [HiddenInput]
        public Guid ClienteId { get; set; }
    }
}