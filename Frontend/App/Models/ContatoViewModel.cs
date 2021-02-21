using System;
using Microsoft.AspNetCore.Mvc;

namespace App.Models
{
    public class ContatoViewModel
    {
        [HiddenInput]
        public Guid ClienteId { get; set; }
        public string Valor { get; set; }
        public int TipoDeContato { get; set; }
    }
}