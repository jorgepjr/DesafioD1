using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Interfaces;
using System;

namespace App.Controllers
{

    public class ClientesController : Controller
    {
        private readonly IClientApi clientApi;

        public ClientesController(IClientApi clientApi)
        {
            this.clientApi = clientApi;
        }

        public async Task<IActionResult> Index()
        {
            var clientes = await clientApi.BuscarClientes();

            return View(clientes);
        }

        public async Task<IActionResult> DadosBasicos(Guid? clienteId)
        {
            if (clienteId is null)
            {
                return View();
            }

            var cliente = await clientApi.BuscarDadosBasicos(clienteId);

            var dadosBasicosViewModel = new DadosBasicosViewModel
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                Rg = cliente.Rg,
                DataDeNascimento = cliente.DataDeNascimento
            };
            TempData["ClienteId"] = dadosBasicosViewModel.Id;
            return View(dadosBasicosViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DadosBasicos(DadosBasicosViewModel dadosBasicosViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(dadosBasicosViewModel);
            }
            var cliente = await clientApi.CadastrarDadosBasicos(dadosBasicosViewModel);

            TempData["ClienteId"] = cliente.Id;

            return RedirectToAction(nameof(Enderecos), new { clienteId = cliente.Id });
        }

        public IActionResult NovoEndereco(Guid clienteId)
        {
            var enderecoViewModel = new EnderecoViewModel { ClienteId = clienteId };
            TempData["ClienteId"] = enderecoViewModel.ClienteId;
            return View(enderecoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SalvarEndereco(EnderecoViewModel enderecoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(enderecoViewModel);
            }
            var endereco = await clientApi.AdicionarEndereco(enderecoViewModel);
            TempData["ClienteId"] = endereco.ClienteId;

            return RedirectToAction(nameof(Enderecos), new {clienteId = endereco.ClienteId});
        }

        public async Task<IActionResult> Enderecos(Guid clienteId)
        {
            TempData["ClienteId"] = clienteId;

            var enderecos = await clientApi.BuscarEnderecosPorClienteId(clienteId);

            if (enderecos is null)
            {
                return View();
            }

            return View(enderecos);
        }

        public async Task<IActionResult> Contatos(Guid clienteId)
        {
             TempData["ClienteId"] = clienteId;
             
            var contatos = await clientApi.BuscarContatosPorClienteId(clienteId);

            if (contatos is null)
            {
                return View();
            }

            return View(contatos);
        }

        public IActionResult NovoContato(Guid clienteId)
        {
            var contatoViewModel = new ContatoViewModel { ClienteId = clienteId };
            TempData["ClienteId"] = contatoViewModel.ClienteId;

            return View(contatoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SalvarContato(ContatoViewModel contatoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(contatoViewModel);
            }
            var contato = await clientApi.AdicionarContato(contatoViewModel);
            TempData["ClienteId"] = contato.ClienteId;

            return RedirectToAction(nameof(Contatos), new {clienteId = contato.ClienteId});
        }
    }
}
