using System;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Dominio;
using Dominio.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatosController : ControllerBase
    {
        private readonly Contexto db;

        public ContatosController(Contexto db)
        {
            this.db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContatoDto contatoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(contatoDto);
            }

            var contato = new Contato(contatoDto.ClienteId ,contatoDto.TipoDeContato, contatoDto.Valor);

            await db.AddAsync(contato);
            await db.SaveChangesAsync();

            return Ok(contato);
        }

        [HttpGet]
        [Route("{clienteId}")]
        public async Task<IActionResult> Get(Guid? clienteId)
        {

            if (clienteId is null)
            {
                return NotFound();
            }
            var contatos = await db.Contatos.Where(x=>x.ClienteId == clienteId).ToListAsync();

             var contatosDto = contatos.Select(contato => new ContatoDto()
            {
                TipoDeContato = contato.TipoDeContato,
                Valor = contato.Valor
                
            });

            return Ok(contatosDto);
        }
    }
}
