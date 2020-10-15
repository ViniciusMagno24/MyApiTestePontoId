using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dominio.Interfaces;
using WebApi.Dominio.Models;

namespace WebApi.Controllers
{
    [AllowAnonymous]
    public class EscolaController : ControllerBase
    {
        IEscolaRepositorio _escolaRepositorio;
        public EscolaController(IEscolaRepositorio escolaRepositorio)
        {
            _escolaRepositorio = escolaRepositorio;
        }

        [HttpPost]
        [Route("v1/escolas/criar")]
        public async Task<IActionResult> Criar([FromBody] Escola escola)
        {
            try
            {
                _escolaRepositorio.Criar(escola);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("v1/escolas/atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] Escola escola)
        {
            try
            {
                _escolaRepositorio.Atualizar(escola);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("v1/escolas/obterporid/{codigoINEP}")]
        public async Task<IActionResult> ObterPorId(string codigoINEP)
        {
            try
            {
                return Ok(_escolaRepositorio.ObterPorId(codigoINEP));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("v1/escolas/obtertodos")]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                return Ok(_escolaRepositorio.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
