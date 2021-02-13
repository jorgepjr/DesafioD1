using System.Collections.ObjectModel;
using System;
using Dominio.Dtos;

namespace Dominio
{
    public class Cliente
    {
        protected Cliente(){}
        public Cliente(ClienteDto clienteDto)
        {
            this.Nome = clienteDto.Nome;
            this.Rg = clienteDto.Rg;
            this.Cpf = clienteDto.Cpf;
            this.DataDeNascimento = clienteDto.DataDeNascimento;

        }
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Rg { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataDeNascimento { get; private set; }
        public Collection<Contato> Contatos { get; private set; } = new Collection<Contato>();
        public Collection<Endereco> Enderecos { get; private set; } = new Collection<Endereco>();
        public Collection<RedeSocial> RedesSociais { get; private set; } = new Collection<RedeSocial>();
    }
}