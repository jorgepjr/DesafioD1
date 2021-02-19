using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using App.Models;

namespace App.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult DadosBasicos()
        {
            return View();
        }

        public IActionResult Enderecos()
        {
            return View();
        }

          public IActionResult Contatos()
        {
            return View();
        }
    }
}
