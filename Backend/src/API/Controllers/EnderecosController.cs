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
    public class EnderecosController : ControllerBase
    {
        private readonly Contexto db;

        public EnderecosController(Contexto db)
        {
            this.db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EnderecoDto enderecoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(enderecoDto);
            }

            var endereco = new Endereco(enderecoDto.ClienteId,
                                        enderecoDto.Cep, enderecoDto.Rua,
                                        enderecoDto.Bairro, enderecoDto.Numero);

            await db.AddAsync(endereco);
            await db.SaveChangesAsync();

            return Ok(endereco);
        }

        [HttpGet]
        [Route("{clienteId}")]
        public async Task<IActionResult> Get(Guid? clienteId)
        {

            if (clienteId is null)
            {
                return NotFound();
            }
            var enderecos = await db.Enderecos.Where(x=>x.ClienteId == clienteId).ToListAsync();

             var enderecosDto = enderecos.Select(endereco => new EnderecoDto()
            {
                Cep = endereco.Cep,
                Bairro = endereco.Bairro,
                Rua = endereco.Rua,
                Numero = endereco.Numero
            });

            return Ok(enderecosDto);
        }
    }
}
