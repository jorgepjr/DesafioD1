using System;
using Dominio.Enums;

namespace Dominio
{
    public class Contato
    {
        protected Contato(){}
        public Contato(Guid clienteId,TipoDeContato tipoDeContato, string numero)
        {
            ClienteId = clienteId;
            TipoDeContato = tipoDeContato;
            Valor = numero;
        }

        public Guid Id { get; private set; }
        public TipoDeContato TipoDeContato { get; private set; }
        public string Valor { get; private set; }
        public Guid ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }
    }
}