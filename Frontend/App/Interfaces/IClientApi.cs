using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using App.Models;
using Refit;

namespace App.Interfaces
{
    public interface IClientApi
    {
        [Post("/clientes")]
        Task<DadosBasicosViewModel> CadastrarDadosBasicos(DadosBasicosViewModel dadosBasicosViewModel);

        [Post("/enderecos")]
        Task<EnderecoViewModel> AdicionarEndereco(EnderecoViewModel enderecoViewModel);

        [Get("/clientes/{clienteId}")]
        Task<DadosBasicosViewModel> BuscarDadosBasicos(Guid? clienteId);

        [Post("/contatos")]
        Task<ContatoViewModel> AdicionarContato(ContatoViewModel contatoViewModel);

        [Get("/enderecos/{clienteId}")]
        Task<List<EnderecoViewModel>> BuscarEnderecosPorClienteId(Guid clienteId);

        [Get("/contatos/{clienteId}")]
        Task<List<ContatoViewModel>> BuscarContatosPorClienteId(Guid clienteId);

        [Get("/clientes")]
        Task<List<DadosBasicosViewModel>> BuscarClientes();

        [Put("/clientes")]
        Task AtualizarDadosBasicos(DadosBasicosViewModel dadosBasicosViewModel);
    }
}