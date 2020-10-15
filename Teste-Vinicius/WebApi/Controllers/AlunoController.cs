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
    public class AlunoController : ControllerBase
    {
        private IAlunoRepositorio _alunoRepositorio;
        public AlunoController(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        [HttpPost]
        [Route("v1/alunos/criar")]
        public async Task<IActionResult> Criar([FromBody] Aluno aluno)
        {
            try
            {
                _alunoRepositorio.Criar(aluno);
                return Ok();
            }
            catch (Exception ex )
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("v1/alunos/atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] Aluno aluno)
        {
            try
            {
                _alunoRepositorio.Atualizar(aluno);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("v1/alunos/obterporid/{id}")]
        public async Task<IActionResult> ObterPorId(string cpf)
        {
            try
            {
                return Ok(_alunoRepositorio.ObterPorId(cpf));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("v1/alunos/obterporturmaid/{turmaId}")]
        public async Task<IActionResult> ObterPorTurmaId(int turmaId)
        {
            try
            {
                return Ok(_alunoRepositorio.ObterPorTurmaId(turmaId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("v1/alunos/obterporcondigoescolar/{codigo}")]
        public async Task<IActionResult> ObterPorCodigoEscolar(string codigo)
        {
            try
            {
                return Ok(_alunoRepositorio.ObterPorCodigoINEP(codigo));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("v1/alunos/obtertodos")]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                return Ok(_alunoRepositorio.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
