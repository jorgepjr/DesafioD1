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

        public IActionResult Enderecos(Guid clienteId)
        {
            var enderecoViewModel = new EnderecoViewModel { ClienteId = clienteId };
            TempData["ClienteId"] = enderecoViewModel.ClienteId;
            return View(enderecoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Enderecos(EnderecoViewModel enderecoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(enderecoViewModel);
            }
            var endereco = await clientApi.AdicionarEndereco(enderecoViewModel);
            TempData["ClienteId"] = endereco.ClienteId;

            return RedirectToAction(nameof(Contatos), new { clienteId = endereco.ClienteId });
        }

        public IActionResult Contatos(Guid clienteId)
        {
            var contatoViewModel = new ContatoViewModel { ClienteId = clienteId };
            return View(contatoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Contatos(ContatoViewModel contatoViewModel)
        {
             if (!ModelState.IsValid)
            {
                return View(contatoViewModel);
            }
            var contato = await clientApi.AdicionarContato(contatoViewModel);
            TempData["ClienteId"] = contato.ClienteId;

            return RedirectToAction(nameof(Contatos), new { clienteId = contato.ClienteId });
        }
    }
}
