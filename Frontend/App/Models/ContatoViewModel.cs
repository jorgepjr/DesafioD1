using System;
using Microsoft.AspNetCore.Mvc;

namespace App.Models
{
    public class ContatoViewModel
    {
        [HiddenInput]
        public Guid ClienteId { get; set; }
    }
}