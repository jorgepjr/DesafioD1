﻿using System;
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
        public async Task<IActionResult> Get()
        {

            var clientes = await db.Clientes.ToListAsync();

            var clientesDto = clientes.Select(cliente => new ClienteDto()
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                Rg = cliente.Rg,
                DataDeNascimento = cliente.DataDeNascimento
            });

            return Ok(clientesDto.ToList());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {

            var cliente = await db.Clientes.FindAsync(id);

            if (cliente is null)
            {
                return NotFound();
            }

            var clineteDto = new ClienteDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Rg = cliente.Rg,
                Cpf = cliente.Cpf,
                DataDeNascimento = cliente.DataDeNascimento
            };

            return Ok(clineteDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ClienteDto clienteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(clienteDto);
            }

            var cliente = await db.Clientes.FirstOrDefaultAsync(x => x.Id == clienteDto.Id);

            if (cliente is null)
            {
                return NotFound();
            }

            cliente.AtualizarDadosBasicos(clienteDto.Nome, clienteDto.Rg, clienteDto.Cpf, clienteDto.DataDeNascimento);
            await db.SaveChangesAsync();

            return Ok(clienteDto);
        }
    }
}
