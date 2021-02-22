using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace App.Models
{
    public class ContatoViewModel
    {
        [HiddenInput]
        public Guid ClienteId { get; set; }

        [DisplayName("Contato")]
        public string Valor { get; set; }
        public int TipoDeContato { get; set; }
    }
}