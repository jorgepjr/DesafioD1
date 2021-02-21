using System;
using Dominio.Enums;

namespace Dominio.Dtos
{
    public class ContatoDto
    {
        public Guid Id { get; set; }
        public string Valor { get; set; }
        public TipoDeContato TipoDeContato { get; set; }
        public Guid ClienteId { get; set; }
    }
}