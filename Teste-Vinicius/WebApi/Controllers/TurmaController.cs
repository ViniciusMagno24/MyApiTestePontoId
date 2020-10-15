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
    public class TurmaController : ControllerBase
    {
        ITurmaRepositorio _turmaRepositorio;
        public TurmaController(ITurmaRepositorio turmaRepositorio)
        {
            _turmaRepositorio = turmaRepositorio;
        }

        [HttpPost]
        [Route("v1/turmas/criar")]
        public async Task<IActionResult> Criar([FromBody] Turma turma)
        {
            try
            {
                _turmaRepositorio.Criar(turma);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("v1/turmas/atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] Turma turma)
        {
            try
            {
                _turmaRepositorio.Atualizar(turma);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("v1/turmas/obterporid/{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            try
            {
                return Ok(_turmaRepositorio.ObterPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("v1/turmas/obterporcodigoescolar/{codigoINEP}")]
        public async Task<IActionResult> ObterPorCodigoEscolar(string codigoINEP)
        {
            try
            {
                return Ok(_turmaRepositorio.ObterPorCodigoEscolar(codigoINEP));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("v1/turmas/obtertodos")]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                return Ok(_turmaRepositorio.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
