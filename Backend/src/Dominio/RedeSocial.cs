using System;
using Dominio.Enums;

namespace Dominio
{
    public class RedeSocial
    {
        public Guid Id { get; private set; }
        public string Link { get; private set; }
        public NomeDaRedeSocial NomeDaRedeSocial { get; private set; }
    }
}