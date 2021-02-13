using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string Rg { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataDeNascimento { get; private set; }
        public IEnumerable<Contato> Contatos { get; private set; }
        public IEnumerable<Endereco> Enderecos { get; private set; }
        public IEnumerable<RedeSocial> RedesSociais { get; private set; }
    }
}