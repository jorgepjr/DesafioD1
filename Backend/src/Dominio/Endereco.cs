using System;

namespace Dominio
{
    public class Endereco
    {
        public Endereco(Guid clienteId, string cep, string rua, string bairro, string numero)
        {
            ClienteId = clienteId;
            Cep = cep;
            Rua = rua;
            Bairro = bairro;
            Numero = numero;
        }

        public Guid Id { get; private set; }
        public string Cep { get; private set; }
        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public string Numero { get; private set; }
        public Guid ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }
    }
}