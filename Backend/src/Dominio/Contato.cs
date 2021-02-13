using System;
using Dominio.Enums;

namespace Dominio
{
    public class Contato
    {
        public Guid Id { get; private set; }
        public string Numero { get; private set; }
        public TipoDeContato TipoDeContato { get; private set; }
    }
}