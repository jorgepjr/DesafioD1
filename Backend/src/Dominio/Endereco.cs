using System;

namespace Dominio
{
    public class Endereco
    {
        public Guid Id { get; private set; }
        public string Cep { get; private set; }
        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public string Numero { get; private set; }
    }
}