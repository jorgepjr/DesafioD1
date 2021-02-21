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
    }
}