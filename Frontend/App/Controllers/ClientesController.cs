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

        public IActionResult DadosBasicos(Guid? clienteId)
        {
            var dadosBasicosViewModel = new DadosBasicosViewModel { };
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
        public IActionResult Contatos()
        {
            return View();
        }
    }
}
