using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace App.Models
{
    public class DadosBasicosViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }

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