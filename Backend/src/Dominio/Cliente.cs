using System.Collections.ObjectModel;
using System;
using Dominio.Dtos;

namespace Dominio
{
    public class Cliente
    {
        protected Cliente(){}
        public Cliente(string nome, string rg, string cpf, DateTime dataDeNascimento)
        {
            Nome = nome;
            Rg = rg;
            Cpf = cpf;
            DataDeNascimento = dataDeNascimento;
        }
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Rg { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataDeNascimento { get; private set; }
        public Collection<Contato> Contatos { get; private set; } = new Collection<Contato>();
        public Collection<Endereco> Enderecos { get; private set; } = new Collection<Endereco>();
        public Collection<RedeSocial> RedesSociais { get; private set; } = new Collection<RedeSocial>();

        public void AtualizarDadosBasicos(string nome, string rg, string cpf, DateTime dataDeNascimento)
        {
            this.Nome = nome;
            this.Rg = rg;
            this.Cpf = cpf;
            this.DataDeNascimento = dataDeNascimento;
        }
    }
}